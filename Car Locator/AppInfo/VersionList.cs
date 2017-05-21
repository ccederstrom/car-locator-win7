using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Information_Page.AppInfo.Version;
using System.Collections.Generic;

namespace Information_Page.AppInfo
{
    public class VersionList
    {
        public List<VersionDetail> ItemList
            = new List<VersionDetail>() {
                new VersionDetail() { VersionNumber="v1.0", Detail="Inital release"},
                 new VersionDetail() { VersionNumber="v2.0", Detail="New UI and Engine"}
        };
    }
}
