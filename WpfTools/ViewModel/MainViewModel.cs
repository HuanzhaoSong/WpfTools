using GalaSoft.MvvmLight;
using WpfTools.Model;
using GalaSoft.MvvmLight.Command;

namespace WpfTools.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// 命令 弹出 字符串调换位置窗体
        /// </summary>
        public RelayCommand ShowFormExchangeStringPositionCommand { get; set; }
        /// <summary>
        /// 命令 弹出 sqlite语句生成窗体
        /// </summary>
        public RelayCommand ShowFormSqliteCommand { get; set; }
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ShowFormExchangeStringPositionCommand = new RelayCommand(ShowFormExchangeStringPosition);
            ShowFormSqliteCommand = new RelayCommand(ShowFormSqlite);
        }

        /// <summary>
        /// 弹出 字符串调换位置窗体
        /// </summary>
        private void ShowFormExchangeStringPosition()
        {
            var d = new View.FormExchangeStringPositionView();
            d.ShowDialog();
        }

        /// <summary>
        /// 弹出 sqlite语句生成窗体
        /// </summary>
        private void ShowFormSqlite()
        {
            var d = new View.FormSqliteView();
            d.ShowDialog();
        }

    }
}