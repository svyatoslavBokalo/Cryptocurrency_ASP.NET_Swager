using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace CryptoCurrency.ApiActions
{

    //this class for actions in api like sorting or searching
    static public class ActionsOfData
    {


        //this method for formatting data for our module without unnecessary "timestamp"
        static public async Task<IList<T>> GetDataFromCoinCap<T>(string url, int count = 10)
        {
            //Task<DataJSON<T>> data = APIClient<T>.GetGeneralCoinCapAsync(url);
            Task<DataJSON<T>> data = APIClient<DataJSON<T>>.GetGeneralAsync(url);
            if (data != null)
            {
                DataJSON<T> result = await data;
                if (result != null && result.data != null)
                {
                    IList<T> items = new List<T>();

                    for (int i = 0; i < result.data.Count; i++)
                    {
                        items.Add(result.data[i]);
                    }

                    return items;
                }
            }

            return null;
        }
    }
}
