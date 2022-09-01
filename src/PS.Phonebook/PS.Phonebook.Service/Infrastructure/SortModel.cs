using PS.Phonebook.Domain.Enums;
using System.Collections.Generic;
using System.Linq;

namespace PS.Phonebook.Service.Infrastructure
{
    public class SortModel
    {
        private string UpIcon { get; set; } = "fa fa-arrow-up";
        private string DownIcon { get; set; } = "fa fa-arrow-down";

        public string SortProperty { get; set; } = null!;
        public SortOrder SortOrder { get; set; }
        private List<SortableColumn> sortableColumns = new List<SortableColumn>();

        public void AddColumn(string colname, bool isDefaultColumn = false)
        {
            var tmp = sortableColumns.Where(x => x.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
                sortableColumns.Add(new SortableColumn() { ColumnName = colname });

            if (isDefaultColumn == true || sortableColumns.Count == 1)
            {
                SortProperty = colname;
                SortOrder = SortOrder.Ascending;
            }
        }

        public SortableColumn GetColumn(string colname)
        {
            var tmp = sortableColumns.Where(x => x.ColumnName.ToLower() == colname.ToLower()).SingleOrDefault();
            if (tmp == null)
                sortableColumns.Add(new SortableColumn() { ColumnName = colname });

            return tmp!;
        }


        public void ApplySort(string sortExpression)
        {

            if (sortExpression == "")
                sortExpression = SortProperty;

            sortExpression = sortExpression.ToLower();


            foreach (SortableColumn column in sortableColumns)
            {
                column.SortIcon = "";
                column.SortExpression = column.ColumnName;

                if (sortExpression == column.ColumnName.ToLower())
                {
                    SortProperty = column.ColumnName;
                    SortOrder = SortOrder.Ascending;
                    column.SortIcon = UpIcon;
                    column.SortExpression = column.ColumnName + "_desc";
                }
                else if (sortExpression == column.ColumnName.ToLower() + "_desc")
                {
                    SortProperty = column.ColumnName;
                    SortOrder = SortOrder.Descending;
                    column.SortIcon = DownIcon;
                    column.SortExpression = column.ColumnName;
                }
            }
        }


    }



    public class SortableColumn
    {
        public string ColumnName { get; set; } = null!;
        public string SortExpression { get; set; } = null!;
        public string SortIcon { get; set; } = null!;
    }

}
