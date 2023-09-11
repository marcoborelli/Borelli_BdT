using Borelli_BdT.presenter;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace Borelli_BdT.utilities {
    public static class Functions {
        //perche' senno' mostrerebbe (giorno . ore : minuti : secondi).
        public static string GetTimeSpanHoursMinutes(TimeSpan tInput) {
            //Truncate perche' se c'e' mezz'ora farebbe .5, Abs perche' se il delta e' negativo sono negativi anche i minuti
            return $"{Math.Truncate(tInput.TotalHours)}h {Math.Abs(tInput.Minutes)}m";
        }

        public static void GetTimeSpanHoursMinutes(EntityTask e) {
            e.Field9 = GetTimeSpanHoursMinutes(TimeSpan.Parse(e.Field9));
        }

        public static void GetTimeSpanHoursMinutes(List<EntityTask> le) {
            for (int i = 0; i < le.Count; i++) {
                GetTimeSpanHoursMinutes(le[i]);
            }
        }

        public static void GetTimeSpanHoursMinutes(EntityUser e) {
            e.Field8 = GetTimeSpanHoursMinutes(TimeSpan.Parse(e.Field8));
            e.Field9 = GetTimeSpanHoursMinutes(TimeSpan.Parse(e.Field9));
        }

        public static void GetTimeSpanHoursMinutes(List<EntityUser> le) {
            for (int i = 0; i < le.Count; i++) {
                GetTimeSpanHoursMinutes(le[i]);
            }
        }
    }
}
