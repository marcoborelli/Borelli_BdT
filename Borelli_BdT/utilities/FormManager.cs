using System;
using MaterialSkin;
using MaterialSkin.Controls;

namespace Borelli_BdT.utilities {
    public static class FormManager {
        private static MaterialSkinManager MaterialSkinManager { get; set; }
        public static void Init() {
            MaterialSkinManager = MaterialSkinManager.Instance;

            MaterialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            MaterialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
        }

        public static void AddForm(MaterialForm f) {
            MaterialSkinManager.AddFormToManage(f);
        }

        public static void ChangeTheme(bool theme) {
            MaterialSkinManager.Theme = theme ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }
    }
}
