/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Scale
 *  Fichier     : Scale_interface.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Interface de la balance pour le projet MALAN_PESAGE
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */
using System;
using System.Collections.Generic;
using System.Text;

namespace Hardware.Scale
{
    internal interface Scale_interface
    {
        bool Scale_connect(string Port_COM);
        bool Scale_disconnect(string Port_COM);
        bool Scale_get_weight(string Port_COM, out double Weight);
    }
}
