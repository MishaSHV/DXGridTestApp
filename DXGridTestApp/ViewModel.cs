using DevExpress.Mvvm;
using System.Collections.ObjectModel;
using System.Data.Entity;

namespace DXGridTestApp
{
    class ViewModel:ViewModelBase
    {
        private NorthwindEntities northwindDbContext;

        public ViewModel()
        {
            if(IsInDesignMode)
            {
                Orders = new ObservableCollection<Orders>();
                Shippers = new ObservableCollection<Shippers>();
                Employees = new ObservableCollection<Employees>();
            }
            else
            {
                northwindDbContext = new NorthwindEntities();

                northwindDbContext.Orders.Load();
                Orders = northwindDbContext.Orders.Local;

                northwindDbContext.Shippers.Load();
                Shippers = northwindDbContext.Shippers.Local;

                northwindDbContext.Employees.Load();
                Employees = northwindDbContext.Employees.Local;
            }
        }

        public ObservableCollection<Orders> Orders
        {
            get => GetValue<ObservableCollection<Orders>>();
            private set => SetValue(value);
        }

        public ObservableCollection<Shippers> Shippers
        {
            get => GetValue<ObservableCollection<Shippers>>();
            private set => SetValue(value);
        }

        public ObservableCollection<Employees> Employees
        {
            get => GetValue<ObservableCollection<Employees>>();
            private set => SetValue(value);
        }
    }
}
