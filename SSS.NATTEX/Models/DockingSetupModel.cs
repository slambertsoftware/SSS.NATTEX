using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;

namespace SSS.NATTEX.Models
{
    public class DockingSetupModel
    {
        public DockingManager DockingManager { get; set; }
        public LayoutAnchorablePane LeftAnchorablePane { get; set; }
        public LayoutAnchorablePane RightAnchorablePane { get; set; }
        public LayoutAnchorable LeftAnchorable { get; set; }
        public LayoutAnchorable RightAnchorable { get; set; }
        public LayoutDocumentPaneGroup DocumentPaneGroup { get; set; }
        public LayoutDocumentPane DocumentPane { get; set; }
        public LayoutDocument Document { get; set; }
        public Grid LeftContentGrid { get; set; }
        public Grid RightContentGrid { get; set; }
    }
}
