using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SSS.NATTEX.Models
{
    public class QuotationItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate QuotationItemTemplate { get; set; }
        public DataTemplate SubTotalItemTemplate { get; set; }
        public DataTemplate AdminHeadingItemTemplate { get; set; }
        public DataTemplate AdminFeeItemTemplate { get; set; }
        public DataTemplate JoiningFeeHeadingTemplate { get; set; }
        public DataTemplate JoiningFeeTemplate { get; set; }
        public DataTemplate MonthlyInstallmentTemplate { get; set; }
        public DataTemplate TotalQuotationValueTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var result = item as QuotationCalculationItem;
            if (result == null)
            {
                return base.SelectTemplate(item, container);
            }

            if (result.IsAdminHeadingItem == true)
            {
                return AdminHeadingItemTemplate;
            }
            else if (result.IsAdminFeeItem == true)
            {
                return AdminFeeItemTemplate;
            }
            else if (result.IsJoiningFeeHeadingItem == true)
            {
                return JoiningFeeHeadingTemplate;
            }
            else if (result.IsJoiningFeeItem == true)
            {
                return JoiningFeeTemplate;
            }
            else if (result.IsMonthlyInstallmentItem == true)
            {
                return MonthlyInstallmentTemplate;
            }
            else if (result.IsSubTotalItem == true)
            {
                return SubTotalItemTemplate;
            }
            else if (result.IsTotalQuotationValueItem == true)
            {
                return TotalQuotationValueTemplate;
            }
            else
            {
                return QuotationItemTemplate;
            }
        }
    }
}
