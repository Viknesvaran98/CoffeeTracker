using System;
using System.Collections.Generic;
using System.Text;
using Firebase;
using Firebase.Database;
using Firebase.Database.Query;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace CoffeeTracker
{
    class FirebaseHelper
    {
        FirebaseClient firebase = new FirebaseClient("https://coffeetrackermad-default-rtdb.asia-southeast1.firebasedatabase.app");
            public async Task AddRecord(string dt, double s, double c, double q, double ri, double pr)
        {
            await firebase
                .Child("CoffeeRecords")
                .PostAsync(new CoffeeRecord() { DateRecorded = dt, Size = s, Cost = c, Quantity = q, ResultIntake = ri, PriceResult = pr });
        }
        public async Task<List<CoffeeRecord>> GetAllBmiRecord()
        {
            return (await firebase
                .Child("CoffeeRecords")
                .OnceAsync<CoffeeRecord>()).Select(item => new CoffeeRecord
                {
                    DateRecorded = item.Object.DateRecorded,
                    Size = item.Object.Size,
                    Cost = item.Object.Cost,
                    Quantity = item.Object.Quantity,
                    ResultIntake = item.Object.ResultIntake,
                    PriceResult = item.Object.PriceResult
                }).ToList();
        }


    }
}
