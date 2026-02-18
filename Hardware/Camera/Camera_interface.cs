/* ==================================================================================================
 *  Projet      : MALAN_PESAGE
 *  Module      : Hardware/Camera
 *  Fichier     : Camera_interface.cs
 *  Auteur      : Paul Paput
 *  Création    : 16/02/26
 *  Description : Interface de la caméra pour le projet MALAN_PESAGE
 *  Historique :
 *      - 16/02/26 : Création de la classe — Paul Paput
 *
 * ================================================================================================ */

using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hardware.Camera
{
    public interface Camera_interface
    {
        bool Camera_connect(string Port_COM);
        bool Camera_disconnect(string Port_COM);
        bool Camera_capture_image(string Port_COM, string Save_path);
    }
}
