using System;
using System.Collections.Generic;
using System.Text;

namespace Computer_Odometer_V2
{
    class Speed
    {
        public static int KMHBox; //Int for the Textbox that sets speed
        public static double MS; //Double for the Output as Decimals are used here.
        public static int MSInt; //Convert the decimal back to Int as the Odo/Trip only seems to like 'whole' numbers
        public static int HMS; //Special Int for 100m calcuations.... Maybe or Definetly.
        public static bool InvalidSpeed;
    }
}
