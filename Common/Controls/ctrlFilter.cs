using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace DVLD
{
    public partial class ctrlFilter : UserControl
    {
        public enum enFilterDataType
        {
            Text = 0,
            Number = 1,
            Bool = 2
        }

        public class clsFilterColumn
        {
            public string FilterText { get; set; }
            public string ColumnName { get; set; }
            public enFilterDataType DataType { get; set; }

            public clsFilterColumn(string filterText, string columnName, enFilterDataType dataType)
            {
                FilterText = filterText;
                ColumnName = columnName;
                DataType = dataType;
            }
        }

        private DataTable _dtSource;
        private DataGridView _dgvSource;
        private Label _lblRecordsCount;
        private List<clsFilterColumn> _FilterColumns = new List<clsFilterColumn>();

        public event EventHandler FilterValueChanged;

        public string SelectedFilterText
        {
            get { return cbFillterBy.Text; }
        }

        public string FilterValue
        {
            get { return txtbFilterBy.Text.Trim(); }
        }

        public ctrlFilter()
        {
            InitializeComponent();
        }

        public void SetFilter(DataTable dtSource, DataGridView dgvSource, Label lblRecordsCount, params clsFilterColumn[] filterColumns)
        {
            _dtSource = dtSource;
            _dgvSource = dgvSource;
            _lblRecordsCount = lblRecordsCount;

            _FilterColumns.Clear();
            cbFillterBy.Items.Clear();
            cbFillterBy.Items.Add("None");

            if (filterColumns != null)
            {
                _FilterColumns.AddRange(filterColumns);

                foreach (clsFilterColumn filterColumn in _FilterColumns)
                {
                    cbFillterBy.Items.Add(filterColumn.FilterText);
                }
            }

            cbFillterBy.SelectedIndex = 0;
            txtbFilterBy.Visible = false;
            txtbFilterBy.Text = string.Empty;
            UpdateRecordsCount();
        }

        public void SetSearchFilter(params clsFilterColumn[] filterColumns)
        {
            _dtSource = null;
            _dgvSource = null;
            _lblRecordsCount = null;

            _FilterColumns.Clear();
            cbFillterBy.Items.Clear();

            if (filterColumns != null)
            {
                _FilterColumns.AddRange(filterColumns);

                foreach (clsFilterColumn filterColumn in _FilterColumns)
                {
                    cbFillterBy.Items.Add(filterColumn.FilterText);
                }
            }

            if (cbFillterBy.Items.Count > 0)
                cbFillterBy.SelectedIndex = 0;

            txtbFilterBy.Visible = cbFillterBy.Items.Count > 0;
            txtbFilterBy.Text = string.Empty;
        }

        public void SetSelectedFilter(string filterText)
        {
            if (cbFillterBy.Items.Contains(filterText))
                cbFillterBy.SelectedItem = filterText;
        }

        public void SetFilterValue(string filterValue)
        {
            txtbFilterBy.Text = filterValue;
        }

        public void ClearFilter()
        {
            if (_dtSource != null)
            {
                _dtSource.DefaultView.RowFilter = string.Empty;
            }

            txtbFilterBy.Text = string.Empty;
            txtbFilterBy.Visible = false;
            cbFillterBy.SelectedIndex = 0;
            UpdateRecordsCount();
        }

        private clsFilterColumn FindFilterColumn()
        {
            foreach (clsFilterColumn filterColumn in _FilterColumns)
            {
                if (filterColumn.FilterText == cbFillterBy.Text)
                    return filterColumn;
            }

            return null;
        }

        private string GetFilterText()
        {
            return txtbFilterBy.Text.Trim().Replace("'", "''");
        }

        private void ApplyFilter()
        {
            clsFilterColumn filterColumn = FindFilterColumn();
            txtbFilterBy.Visible = filterColumn != null;

            if (_dtSource == null)
                return;

            if (filterColumn == null || txtbFilterBy.Text.Trim() == string.Empty)
            {
                _dtSource.DefaultView.RowFilter = string.Empty;
                UpdateRecordsCount();
                return;
            }

            string filterText = GetFilterText();

            if (filterColumn.DataType == enFilterDataType.Text)
                _dtSource.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", filterColumn.ColumnName, filterText);
            else
                _dtSource.DefaultView.RowFilter = string.Format("Convert([{0}], 'System.String') LIKE '%{1}%'", filterColumn.ColumnName, filterText);

            UpdateRecordsCount();
        }

        private void UpdateRecordsCount()
        {
            if (_lblRecordsCount == null)
                return;

            if (_dtSource != null)
                _lblRecordsCount.Text = _dtSource.DefaultView.Count.ToString();
            else if (_dgvSource != null)
                _lblRecordsCount.Text = _dgvSource.Rows.Count.ToString();
        }

        private void cbFillterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtbFilterBy.Text = string.Empty;
            ApplyFilter();
            FilterValueChanged?.Invoke(this, EventArgs.Empty);
        }

        private void txtbFilterBy_TextChanged(object sender, EventArgs e)
        {
            ApplyFilter();
            FilterValueChanged?.Invoke(this, EventArgs.Empty);
        }

    }
}
