using System;
using System.Windows.Forms;

namespace MalikP.Controls.Pagination
{
    public sealed partial class PaginationControl : UserControl
    {
        #region Fields

        public delegate bool PaginationCallBack();
        public PaginationCallBack NextPageHandler { get; set; }
        public PaginationCallBack PrevPageHandler { get; set; }
        public PaginationCallBack ComboBoxPageHandler { get; set; }
        public PaginationCallBack ChangePageCallBack { get; set; }
        public event Pagination.PaginationEventHandler CurrentPageChanged;
        private void OnCurrentPageChange()
        {
            if (CurrentPageChanged != null) CurrentPageChanged(this,
                   new PaginationEventArgs()
                   {
                       CurrentPage = _pagination.CurrentPage,
                       TotalPages = _pagination.TotalPages,
                       FromRecord = _pagination.FromRecord,
                       ToRecord = _pagination.ToRecord
                   });
        }
        private Pagination _pagination;
        public Pagination.PageingInfo PaginationInfoSelector { get; set; }


        #endregion

        public PaginationControl()
        {
            InitializeComponent();
            _pagination = new Pagination();
            this.PaginationInfoSelector = Pagination.PageingInfo.CurrentAndTotalPage;
            CheckIfIsMorePagenable(new PaginationEventArgs()
            {
                CurrentPage = _pagination.CurrentPage,
                FromRecord = _pagination.FromRecord,
                ToRecord = _pagination.ToRecord,
                TotalPages = _pagination.TotalPages
            });
            this._pagination.CurrentPageChanged += ProcessPageChangeInternal;
            SetDropDownStyle(ComboBoxStyle.DropDownList);
        }

        #region Private

        private void ComboBoxPageChange(object sender, PaginationEventArgs e)
        {
            throw new NotImplementedException();
        }
        private void ProcessPageChange(object sender)
        {
            Button btn = (Button)sender;

            if (btn != null)
            {
                if (btn.Name == this.prevBtn.Name)
                {
                    _pagination.PrevPage();
                }
                if (btn.Name == this.nextBtn.Name)
                {
                    _pagination.NextPage();
                }
                if (btn.Name == this.firstPageBtn.Name)
                {
                    _pagination.FirstPage();
                }
                if (btn.Name == this.lastPageBtn.Name)
                {
                    _pagination.LastPage();
                }
            }
            else
            {
                throw new ArgumentNullException("Sender can not be null");
            }
        }

        private void ProcessPageChangeInternal(object sender, PaginationEventArgs e)
        {
            ShowPageInfo();
            OnCurrentPageChange();
            CheckIfIsMorePagenable(e);
        }
        private void ShowPageInfo()
        {
            this.currentAndTotalPagesInfoTb.Text = _pagination.GetPaginationInfo(this.PaginationInfoSelector);
            this.totalRecordsInfoLbl.Text = _pagination.GetPaginationInfo(paginationInfoSelector: Pagination.PageingInfo.TotalRecords);
        }
        private void CheckIfIsMorePagenable(PaginationEventArgs e)
        {
            if (e.CurrentPage == e.TotalPages)
                this.nextBtn.Enabled = false;
            else
                this.nextBtn.Enabled = true;

            if (e.CurrentPage == e.TotalPages)
                this.lastPageBtn.Enabled = false;
            else
                this.lastPageBtn.Enabled = true;

            if (e.CurrentPage == 1 || e.CurrentPage == 0)
                this.prevBtn.Enabled = false;
            else
                this.prevBtn.Enabled = true;

            if (e.CurrentPage == 1 || e.CurrentPage == 0)
                this.firstPageBtn.Enabled = false;
            else
                this.firstPageBtn.Enabled = true;

            if (setPageCb.Items.Count > 0)
            {
                setPageCb.Enabled = true;

                this.setPageCb.SelectedIndexChanged -= new System.EventHandler(this.PageChangedByComboBox);
                setPageCb.SelectedItem = e.CurrentPage.ToString();
                this.setPageCb.SelectedIndexChanged += new System.EventHandler(this.PageChangedByComboBox);
            }
            else
            {
                setPageCb.Enabled = false;
            }
        }
        private bool SetComboBoxItems()
        {
            if (_pagination.TotalRecords > 0)
            {
                for (var i = 1; i <= _pagination.TotalPages; i++)
                {
                    this.setPageCb.Items.Add(i.ToString());
                }
                this.setPageCb.SelectedItem = _pagination.CurrentPage;
                return true;
            }
            return false;
        }
        private void PageChangedByComboBox(object sender, EventArgs e)
        {
            var cb = (ComboBox)sender;
            if (ChangePageCallBack != null || ChangePageCallBack != null)
            {
                if (ComboBoxPageHandler != null)
                    if (ComboBoxPageHandler())
                    {
                        this._pagination.ChangeCurrentPage(int.Parse(cb.SelectedItem.ToString()));
                    }

                if (ChangePageCallBack != null)
                {
                    if (ChangePageCallBack())
                    {
                        this._pagination.ChangeCurrentPage(int.Parse(cb.SelectedItem.ToString()));
                    }
                }
            }
            else
            {
                this._pagination.ChangeCurrentPage(int.Parse(cb.SelectedItem.ToString()));
            }
        }

        private void NextPage(object sender, EventArgs e)
        {
            if (NextPageHandler != null || ChangePageCallBack != null)
            {
                if (NextPageHandler != null)
                {
                    if (NextPageHandler())
                    {
                        ProcessPageChange(sender);
                    }
                }

                if (ChangePageCallBack != null)
                {
                    if (ChangePageCallBack())
                    {
                        ProcessPageChange(sender);
                    }
                }
            }
            else
            {
                ProcessPageChange(sender);
            }
        }
        private void PrevPage(object sender, EventArgs e)
        {
            if (PrevPageHandler != null || ChangePageCallBack != null)
            {
                if (PrevPageHandler != null)
                    if (PrevPageHandler())
                    {
                        ProcessPageChange(sender);
                    }

                if (ChangePageCallBack != null)
                    if (ChangePageCallBack())
                    {
                        ProcessPageChange(sender);
                    }
            }
            else
            {
                ProcessPageChange(sender);
            }
        }
        private void FirstPage(object sender, EventArgs e)
        {
            if (ChangePageCallBack != null)
            {
                if (ChangePageCallBack())
                {
                    ProcessPageChange(sender);
                }
            }
            else
            {
                ProcessPageChange(sender);
            }
        }
        private void LastPage(object sender, EventArgs e)
        {
            if (ChangePageCallBack != null)
            {
                if (ChangePageCallBack())
                {
                    ProcessPageChange(sender);
                }
            }
            else
            {
                ProcessPageChange(sender);
            }
        }

        #endregion

        #region Public

        public void SetRecordsPerPage(int recordsCount)
        {
            if (_pagination == null) _pagination = new Pagination();
            _pagination.RecordsPerPage = recordsCount;
        }
        public bool SetPaginationtTotalRecords(int recordsCount)
        {
            if (_pagination == null) _pagination = new Pagination();
            _pagination.TotalRecords = recordsCount;

            var valueOfCb = SetComboBoxItems();
            ProcessPageChangeInternal(this,
                new PaginationEventArgs()
                {
                    CurrentPage = _pagination.CurrentPage,
                    TotalPages = _pagination.TotalPages,
                    FromRecord = _pagination.FromRecord,
                    ToRecord = _pagination.ToRecord
                });
            return valueOfCb;
        }
        public Pagination GetPagination
        {
            get
            {
                return this._pagination;
            }
        }
        public void NextPage()
        {
            PrevPage(nextBtn, EventArgs.Empty);
        }
        public void PrevPage()
        {
            PrevPage(prevBtn, EventArgs.Empty);
        }
        public void LastPage()
        {
            LastPage(lastPageBtn, EventArgs.Empty);
        }
        public void FirstPage()
        {
            FirstPage(firstPageBtn, EventArgs.Empty);
        }
        public bool IsArmed
        {
            get
            {
                return this._pagination.IsArmed;
            }
        }
        public void ArmRearm(Pagination.ArmDisarmSelector selector)
        {
            _pagination.ArmDisarm(selector);
        }
        public void ClearPaging()
        {
            this._pagination.CurrentPageChanged -= ProcessPageChangeInternal;
            this._pagination.ClearPaging();
            this.setPageCb.Items.Clear();
            CheckIfIsMorePagenable(new PaginationEventArgs()
            {
                CurrentPage = _pagination.CurrentPage,
                FromRecord = _pagination.FromRecord,
                ToRecord = _pagination.ToRecord,
                TotalPages = _pagination.TotalPages
            });
            this._pagination.CurrentPageChanged += ProcessPageChangeInternal;
        }

        public void EnableDisableControl(bool value)
        {
            lastPageBtn.Enabled = !value;
            firstPageBtn.Enabled = !value;
            nextBtn.Enabled = !value;
            prevBtn.Enabled = !value;
            setPageCb.Enabled = !value;
            CheckIfIsMorePagenable(
                new PaginationEventArgs()
                {
                    CurrentPage = _pagination.CurrentPage,
                    TotalPages = _pagination.TotalPages,
                    FromRecord = _pagination.FromRecord,
                    ToRecord = _pagination.ToRecord
                });
        }

        public void Enable()
        {
            lastPageBtn.Enabled = true;
            firstPageBtn.Enabled = true;
            nextBtn.Enabled = true;
            prevBtn.Enabled = true;
            setPageCb.Enabled = true;
        }


        public void Disable()
        {
            lastPageBtn.Enabled = false;
            firstPageBtn.Enabled = false;
            nextBtn.Enabled = false;
            prevBtn.Enabled = false;
            setPageCb.Enabled = false;
        }

        public void SetDropDownStyle(ComboBoxStyle style)
        {
            setPageCb.DropDownStyle = style;
        }
        #endregion
    }
}
