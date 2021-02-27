using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXGridTestApp
{
    public enum FileType
    {
        Text,
        Csv
    }

    public interface IExportFileType
    {
        string Filter { get;}
        FileType FileType { get; }
        int FilterIndex { get; }
        void Export(DataViewBase dataViewBase, Stream stream);
    }

    public static class ExportFileType 
    {
        public static IExportFileType TextFileType = new TextFileType();
        public static IExportFileType CsvFileType = new CsvFileType();
    }

    class TextFileType : IExportFileType
    {
        public string Filter => "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        public FileType FileType => FileType.Text; 
        public int FilterIndex => 1;

        public void Export(DataViewBase dataViewBase, Stream stream)
        {
            dataViewBase.ExportToText(stream);
        }
    }

    class CsvFileType : IExportFileType
    {
        public string Filter => "csv files (*.csv)|*.csv|All files (*.*)|*.*";
        public FileType FileType => FileType.Csv;
        public int FilterIndex => 1;

        public void Export(DataViewBase dataViewBase, Stream stream)
        {
            dataViewBase.ExportToCsv(stream);
        }
    }
}
