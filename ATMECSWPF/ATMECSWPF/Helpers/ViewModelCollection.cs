using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMECSWPF.Helpers
{
    public class ViewModelCollection
    {
        public static int CONTACTSEDITVIEWMODEL = 1;
        public static int MAINWINDOWVIEWMODEL = 2;
        public static int NAVIGATIONITEMVIEWMODEL = 3;
        public static int NAVIGATIONVIEWMODEL = 4;

        public static Dictionary<int, object> viewModelContainer = new Dictionary<int, object>();

        public ViewModelCollection()
        {

        }

        public static void AddViewModel(int viewModelId, object viewModel)
        {
             object existingViewModel = viewModelContainer.FirstOrDefault(e => e.Key == viewModelId);

             if (existingViewModel == null)
             {
                  viewModelContainer.Add(viewModelId, viewModel);
             }
             else
             {
                  viewModelContainer.Remove(viewModelId);
                  viewModelContainer.Add(viewModelId, viewModel);
             }
        }

        public static object GetViewModel(int viewModelId)
        {
            object viewModel = viewModelContainer.FirstOrDefault(e => e.Key == viewModelId).Value;

            return viewModel;
        }
     }
}
