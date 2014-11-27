using System;

namespace MalikP.Controls.Pagination
{
    public class Pagination
    {
        public enum ArmDisarmSelector { Arm, Disarm }
        public enum PageingInfo
        {
            CurrentPage,
            CurrentAndTotalPage,
            FromRecord,
            ToRecord,
            FromToRecord,
            FromRecordPageToRecord,
            TotalRecords
        }

        private object _lock = new object();

        public delegate void PaginationEventHandler(object sender, PaginationEventArgs e);
        public event PaginationEventHandler PagedNext;
        public event PaginationEventHandler PagedPrev;
        public event PaginationEventHandler CurrentPageChanged;

        private delegate void InternalEventDelegate();
        private event InternalEventDelegate _RecordsCountChanged;
        private event InternalEventDelegate _CurrentPageChanged;

        public int ToRecord { get; private set; }
        public int RecordsPerPage { get; set; }
        public int FromRecord { get; private set; }
        public int TotalPages { get; private set; }
        private int _recordsCount;
        private int _currentPage;
        private bool _isArmed;

        private void OnPagedNext()
        {
            if (PagedNext != null) PagedNext(this,
                new PaginationEventArgs()
                {
                    CurrentPage = this._currentPage,
                    TotalPages = this.TotalPages,
                    FromRecord = this.FromRecord,
                    ToRecord = this.ToRecord
                });
        }
        private void OnPagedPrev()
        {
            if (PagedPrev != null) PagedPrev(this,
                new PaginationEventArgs()
                {
                    CurrentPage = this._currentPage,
                    TotalPages = this.TotalPages,
                    FromRecord = this.FromRecord,
                    ToRecord = this.ToRecord
                });
        }
        private void OnRecordsCountChange()
        {
            if (_RecordsCountChanged != null) _RecordsCountChanged();
        }
        private void OnCurrentPageChange(bool internalEvent)
        {
            if (internalEvent)
            {
                if (_CurrentPageChanged != null) _CurrentPageChanged();
            }
            else
            {
                if (CurrentPageChanged != null) CurrentPageChanged(this,
                    new PaginationEventArgs()
                {
                    CurrentPage = this._currentPage,
                    TotalPages = this.TotalPages,
                    FromRecord = this.FromRecord,
                    ToRecord = this.ToRecord
                });
            }
        }

        public Pagination()
        {
            lock (_lock)
            {
                _isArmed = false;
                ClearPaging();

                this._RecordsCountChanged += SetPaging;
                this._CurrentPageChanged += SetVariablesAfterActualPageChanged;
                _isArmed = true;
            }
        }

        public void ClearPaging()
        {
            lock (_lock)
            {
                this._recordsCount = 0;
                this.RecordsPerPage = 0;
                this.TotalPages = 0;
                this.CurrentPage = 0;
                this.FromRecord = 0;
                this.ToRecord = 0;
            }
        }
        private void SetVariablesAfterActualPageChanged()
        {
            lock (_lock)
            {
                int fromRecordTemp = ((this.CurrentPage - 1) * this.RecordsPerPage) + 1;
                if (fromRecordTemp <= 0) fromRecordTemp = 1;
                this.FromRecord = fromRecordTemp;


                int torecordTemp = ((this.CurrentPage - 1) * this.RecordsPerPage) + this.RecordsPerPage;
                if (torecordTemp > _recordsCount) torecordTemp = _recordsCount;
                this.ToRecord = torecordTemp;
            }
        }
        private void SetPaging()
        {
            lock (_lock)
            {
                int totalTemp = _recordsCount / this.RecordsPerPage;
                if ((totalTemp * this.RecordsPerPage) < _recordsCount)
                {
                    totalTemp++;
                }
                this.TotalPages = totalTemp;
                if (this.TotalPages > 0)
                {
                    this.CurrentPage = 1;
                }
            }
        }
        public int TotalRecords
        {
            set
            {
                if (this._recordsCount != value && value > 0)
                {
                    this._recordsCount = value;
                    OnRecordsCountChange();
                }
            }

            get
            {
                return this._recordsCount;
            }
        }
        public bool NextPage()
        {
            lock (_lock)
            {
                int actualPageTemp = this.CurrentPage;
                actualPageTemp++;
                if (actualPageTemp <= this.TotalPages && actualPageTemp > 0)
                {
                    this.CurrentPage = actualPageTemp;

                    OnPagedNext();
                    OnCurrentPageChange(false);

                    return true;
                }
                return false;
            }
        }

        public bool PrevPage()
        {
            lock (_lock)
            {
                int actualPageTemp = this.CurrentPage;
                actualPageTemp--;

                if (actualPageTemp <= this.TotalPages && actualPageTemp > 0)
                {
                    this.CurrentPage = actualPageTemp;

                    OnPagedPrev();
                    OnCurrentPageChange(false);
                    return true;
                }
                return false;
            }
        }

        public bool FirstPage()
        {
            lock (_lock)
            {
                if (this.TotalPages > 0 && this.CurrentPage != 1)
                {
                    this.CurrentPage = 1;
                    OnPagedPrev();
                    OnCurrentPageChange(false);
                    return true;
                }
                return false;
            }
        }

        public bool LastPage()
        {
            lock (_lock)
            {
                if (this.TotalPages > 0 && this.CurrentPage < this.TotalPages)
                {
                    this.CurrentPage = this.TotalPages;
                    OnPagedNext();
                    OnCurrentPageChange(false);
                    return true;
                }
                return false;
            }
        }

        public int CurrentPage
        {
            get { return this._currentPage; }
            set
            {
                this._currentPage = value;
                OnCurrentPageChange(true);
            }
        }
        public string GetPaginationInfo(PageingInfo paginationInfoSelector)
        {
            lock (_lock)
            {
                switch (paginationInfoSelector)
                {
                    case PageingInfo.CurrentAndTotalPage:
                        return string.Format("{0} / {1}", this.CurrentPage.ToString(), this.TotalPages.ToString());
                    case PageingInfo.TotalRecords:
                        return string.Format("{0}", this.TotalRecords.ToString());
                    case PageingInfo.CurrentPage:
                        return string.Format("{0}", this.CurrentPage.ToString());
                    case PageingInfo.FromRecord:
                        return string.Format("{0}", this.FromRecord.ToString());
                    case PageingInfo.ToRecord:
                        return string.Format("{0}", this.ToRecord.ToString());
                    case PageingInfo.FromToRecord:
                        return string.Format("{0} / {1}", this.FromRecord.ToString(), this.ToRecord.ToString());
                    case PageingInfo.FromRecordPageToRecord:
                        return string.Format("{0} - {1} - {2}", this.FromRecord.ToString(), this.CurrentPage.ToString(), this.ToRecord.ToString());
                    default:
                        throw new ArgumentException("You have to use correct selector.");
                }
            }
        }
        public void ChangeCurrentPage(int pageNumber)
        {
            lock (_lock)
            {
                if (this.CurrentPage != pageNumber)
                {
                    this.CurrentPage = pageNumber;
                    OnCurrentPageChange(false);
                }
            }
        }
        public void ArmDisarm(ArmDisarmSelector selector)
        {
            switch (selector)
            {
                case ArmDisarmSelector.Arm:
                    if (this._RecordsCountChanged == null)
                        this._RecordsCountChanged += SetPaging;
                    if (this._CurrentPageChanged == null)
                        this._CurrentPageChanged += SetVariablesAfterActualPageChanged;
                    _isArmed = true;
                    break;
                case ArmDisarmSelector.Disarm:
                    if (this._RecordsCountChanged != null)
                        this._RecordsCountChanged -= SetPaging;
                    if (this._CurrentPageChanged != null)
                        this._CurrentPageChanged -= SetVariablesAfterActualPageChanged;
                    _isArmed = false;
                    break;
                default: throw new ArgumentException("Selector have to be set properly.");
            }
        }

        public bool IsArmed
        {
            get
            {
                return _isArmed;
            }
        }
    }

    public class PaginationEventArgs : EventArgs
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int FromRecord { get; set; }
        public int ToRecord { get; set; }
        public PaginationEventArgs() { }
    }


}
