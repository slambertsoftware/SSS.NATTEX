using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SSS.NATTEX.Models
{
    public class DataImportItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate HeaderColumnsDataTemplate { get; set; }
        public DataTemplate ImportItemColumnsDataTemplate { get; set; }
        public DataTemplate ImportItemSummaryDataTemplate { get; set; }
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {

            var result = item as DataImportItem;
            if (result == null)
            {
                return base.SelectTemplate(item, container);
            }
            else if (result.IsHeadersItem)
            {
                return HeaderColumnsDataTemplate;
            }
            else if (result.IsPolicyScheduleSummaryItem)
            {
                return ImportItemSummaryDataTemplate;
            }
            else
            {
                return ImportItemColumnsDataTemplate;
            }
        }
    }
}
