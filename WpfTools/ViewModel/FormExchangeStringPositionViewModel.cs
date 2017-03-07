using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace WpfTools.ViewModel
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class FormExchangeStringPositionViewModel : ViewModelBase
    {
        private string middleStr = "=";
        /// <summary>
        /// 中间字符
        /// </summary>
        public string MiddleStr
        {
            get { return middleStr; }
            set
            {
                middleStr = value;
                RaisePropertyChanged(() => MiddleStr);
            }
        }

        private string endStr = ";";
        /// <summary>
        /// 结束字符
        /// </summary>
        public string EndStr
        {
            get { return endStr; }
            set
            {
                endStr = value;
                RaisePropertyChanged(() => EndStr);
            }
        }

        private string extraStr = ".ToString()";
        /// <summary>
        /// 额外的字符
        /// </summary>
        public string ExtraStr
        {
            get { return extraStr; }
            set
            {
                extraStr = value;
                RaisePropertyChanged(() => ExtraStr);
            }
        }

        private bool add;
        /// <summary>
        /// 加上额外字符
        /// </summary>
        public bool Add
        {
            get { return add; }
            set
            {
                add = value;
                RaisePropertyChanged(() => Add);
            }
        }

        private bool minus;
        /// <summary>
        /// 减去额外字符
        /// </summary>
        public bool Minus
        {
            get { return minus; }
            set
            {
                minus = value;
                RaisePropertyChanged(() => Minus);
            }
        }

        private string olderStr;
        /// <summary>
        /// 转换前的字符
        /// </summary>
        public string OlderStr
        {
            get { return olderStr; }
            set
            {
                olderStr = value;
                RaisePropertyChanged(() => OlderStr);
            }
        }

        private string newerStr;
        /// <summary>
        /// 转换后的字符
        /// </summary>
        public string NewerStr
        {
            get { return newerStr; }
            set
            {
                newerStr = value;
                RaisePropertyChanged(() => NewerStr);
            }
        }

        public RelayCommand StartCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the FormExchangeStringPositionViewModel class.
        /// </summary>
        public FormExchangeStringPositionViewModel()
        {
            StartCommand = new RelayCommand(Start);
        }

        private void Start()
        {
            olderStr = olderStr.Replace(" ", "");
            string[] arrayStrs = olderStr.Split(endStr.ToCharArray()[0]);

            newerStr = "";
            foreach (string str in arrayStrs)
            {
                if (string.IsNullOrEmpty(str)) continue;
                string temp = str.Replace(" ", "").Trim();
                string[] array = temp.Split(middleStr.ToCharArray()[0]);

                if (minus)
                {
                    int index = array[1].IndexOf(extraStr);
                    if (index != -1)
                        newerStr += array[1].Substring(0, index) + middleStr + array[0] + endStr + System.Environment.NewLine;
                    else
                        newerStr += array[1] + middleStr + array[0] + endStr + System.Environment.NewLine;
                }
                else if (add)
                {
                    newerStr += array[1] + middleStr + array[0] + extraStr + endStr + System.Environment.NewLine;
                }
            }
            NewerStr = newerStr;
        }
    }
}