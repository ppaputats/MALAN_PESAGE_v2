using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace Hardware
{
    public class Hardware_manager
    {
        // On stocke l'objet complet pour avoir accès au HardwareName ET au Status
        private readonly Dictionary<string, PortMapping> _portMap;
        public Hardware_manager()
        {
            var baseDir = AppContext.BaseDirectory;

            // Scan des lieux de stockage probables 
            var candidates = new[]
            {
                Path.Combine(baseDir, "Port.json"),
                Path.Combine(baseDir, "config", "ports.json")
            };

            var path = candidates.FirstOrDefault(File.Exists);
            foreach (var indexer in candidates)
            {
                Console.WriteLine($"Vérification de l'existence du fichier : {indexer}");
            }
            if (path == null)
            {
                throw new FileNotFoundException(
                    "Port.json introuvable. Emplacements testés :\n" +
                    string.Join(Environment.NewLine, candidates)
                );
            }

            PortConfig cfg;
            try
            {
                var json = File.ReadAllText(path);
                cfg = JsonSerializer.Deserialize<PortConfig>(
                    json,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );
            }
            catch (JsonException jex)
            {
                throw new InvalidDataException($"Le fichier Port.json est invalide : {jex.Message}", jex);
            }

            if (cfg?.Ports == null || cfg.Ports.Count == 0)
                throw new InvalidDataException("Port.json ne contient aucune entrée dans 'ports'.");

            // Détection de doublons
            var dupes = cfg.Ports
                           .GroupBy(p => p.SoftwareName ?? string.Empty, StringComparer.OrdinalIgnoreCase)
                           .Where(g => g.Count() > 1)
                           .Select(g => g.Key)
                           .ToList();

            if (dupes.Count > 0)
                throw new InvalidDataException(
                    "Clés 'softwareName' dupliquées dans Port.json : " + string.Join(", ", dupes)
                );

            _portMap = cfg.Ports.ToDictionary(
                p => EnsureNotEmpty(p.SoftwareName, nameof(PortMapping.SoftwareName)),
                p => p,
                StringComparer.OrdinalIgnoreCase
            );
        }

        public bool TryGetPort(string softwareName, out string hardwareName)
        {
            // Lien entre le nom software et le nom harware
            hardwareName = null;
            if (string.IsNullOrWhiteSpace(softwareName))
                return false;

            if (_portMap.TryGetValue(softwareName, out var mapping))
            {
                hardwareName = mapping.HardwareName;
                return true;
            }
            return false;
        }

        // Récupération du status du compososant
        public string GetStatus(string softwareName)
        {
            return _portMap.TryGetValue(softwareName, out var mapping) ? mapping.Status : "Unknown";
        }

        private static string EnsureNotEmpty(string value, string field)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new InvalidDataException($"Champ '{field}' manquant ou vide dans Port.json.");
            return value;
        }

        // ----------------- Modèles JSON -----------------

        public sealed class PortConfig
        {
            public List<PortMapping> Ports { get; set; } = new List<PortMapping>();
        }

        public sealed class PortMapping
        {
            public string SoftwareName { get; set; } = "";
            public string HardwareName { get; set; } = "";
            public string Status { get; set; } = "";
        }
    }
}