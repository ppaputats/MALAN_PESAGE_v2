/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Printer
 *  Fichier     : Printer_interface.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Interface de l'imprimante pour le projet MALAN_PESAGE
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */

using System;
using System.Collections.Generic;
using System.Text;
using Common;

namespace Hardware.Printer
{
    internal interface Printer_interface
    {
        bool Printer_connect(string Ip_address);
        bool Printer_disconnect(string Ip_address);
        bool Printer_send(string Ip_address, string ZPL_path);
    }
}
