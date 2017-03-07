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
    public class FormSqliteViewModel : ViewModelBase
    {
        private string olderFields;
        /// <summary>
        /// 要修改的字段集合
        /// </summary>
        public string OlderFields
        {
            get { return olderFields; }
            set
            {
                olderFields = value;
                RaisePropertyChanged(() => OlderFields);
            }
        }

        private string filter = ",";
        /// <summary>
        /// 字段间的分隔符
        /// </summary>
        public string Filter
        {
            get { return filter; }
            set
            {
                filter = value;
                RaisePropertyChanged(() => Filter);
            }
        }

        private string insertStr = "@";
        /// <summary>
        /// 要插入到字段间的字符
        /// </summary>
        public string InsertStr
        {
            get { return insertStr; }
            set
            {
                insertStr = value;
                RaisePropertyChanged(() => InsertStr);
            }
        }

        private string tableName;
        /// <summary>
        /// 表名称
        /// </summary>
        public string TableName
        {
            get { return tableName; }
            set
            {
                tableName = value;
                RaisePropertyChanged(() => TableName);
            }
        }

        private string newerFields;
        /// <summary>
        /// 插入字符之后的字段集合
        /// </summary>
        public string NewerFields
        {
            get { return newerFields; }
            set
            {
                newerFields = value;
                RaisePropertyChanged(() => NewerFields);
            }
        }

        private string insertSql;
        /// <summary>
        /// 生成的插入语句
        /// </summary>
        public string InsertSql
        {
            get { return insertSql; }
            set
            {
                insertSql = value;
                RaisePropertyChanged(() => InsertSql);
            }
        }

        private string columns;
        /// <summary>
        /// 生成表所需的字段
        /// </summary>
        public string Columns
        {
            get { return columns; }
            set
            {
                columns = value;
                RaisePropertyChanged(() => Columns);
            }
        }

        private string drDatas;
        /// <summary>
        /// 生成表所需插入的行数据
        /// </summary>
        public string DrDatas
        {
            get { return drDatas; }
            set
            {
                drDatas = value;
                RaisePropertyChanged(() => DrDatas);
            }
        }

        private string parameters;
        /// <summary>
        /// 生成的字段参数
        /// </summary>
        public string Parameters
        {
            get { return parameters; }
            set
            {
                parameters = value;
                RaisePropertyChanged(() => Parameters);
            }
        }

        public RelayCommand StartCommand { get; set; }

        /// <summary>
        /// Initializes a new instance of the FormSqliteViewModel class.
        /// </summary>
        public FormSqliteViewModel()
        {
            StartCommand = new RelayCommand(Start);
        }

        private void Start()
        {
            olderFields = olderFields.Replace(" ", "");
            string[] fields = olderFields.Split(filter.ToCharArray()[0]);

            newerFields = "";
            foreach (string field in fields)
            {
                if (string.IsNullOrEmpty(field)) continue;

                newerFields += insertStr + field + filter;
            }
            if (newerFields.LastIndexOf(filter.ToCharArray()[0]) == newerFields.Length - 1)
                newerFields = newerFields.Substring(0, newerFields.Length - 1);
            NewerFields = newerFields;

            insertSql = "select " + olderFields + " from " + tableName + System.Environment.NewLine;
            insertSql += System.Environment.NewLine;
            insertSql += "replace into " + tableName + " (" + olderFields + ") values (" + NewerFields + ")";
            InsertSql = insertSql;

            columns = "";
            drDatas = "";
            parameters = "";
            foreach (string field in fields)
            {
                if (string.IsNullOrEmpty(field)) continue;

                columns += "dtInsert.Columns.Add(\"" + field + "\", Type.GetType(\"System.String\"));" + System.Environment.NewLine;
                drDatas += "drData[\"" + field + "\"] = row[\"" + field + "\"];" + System.Environment.NewLine;

                if (fields[0] == field)
                    parameters += "SQLiteParameter orclParam = new SQLiteParameter();" + System.Environment.NewLine;
                else
                    parameters += "orclParam = new SQLiteParameter();" + System.Environment.NewLine;
                parameters += "orclParam.ParameterName = \"" + insertStr + field + "\";" + System.Environment.NewLine;
                parameters += "orclParam.DbType = DbType.String;" + System.Environment.NewLine;
                parameters += "orclParam.Size = 40;" + System.Environment.NewLine;
                parameters += "orclParam.SourceColumn = \"" + field + "\";" + System.Environment.NewLine;
                parameters += "orclParams.Add(orclParam);" + System.Environment.NewLine;
                parameters += System.Environment.NewLine;
            }

            Columns = columns;
            DrDatas = drDatas;
            Parameters = parameters;
        }
    }
}