using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    class Program {
        public static string NEW_LINE = "\r\n";

        static void Main(string[] args){
            Photo photo = new Photo();
            Type[] arrayOfTypes = findAllTypesFromFiltersNamespace();
            showFilterList(arrayOfTypes);
            Console.WriteLine(NEW_LINE + "Set the filter number: ");
            int inputKey = getInputKey();
            applySelectedFilter(arrayOfTypes, inputKey, photo);

            Console.WriteLine(NEW_LINE + "The program is completed, press ENTER to exit.");

            Console.ReadLine();
        }

        private static void applySelectedFilter(Type[] arrayOfTypes, int selectedFilter, Photo photo){
            if (selectedFilter - 1 >= arrayOfTypes.Length){
                exitFromApp("There is no filter with this index.");
            }
            Type type = arrayOfTypes[selectedFilter - 1];
            object targetFilter = Activator.CreateInstance(Type.GetType(type.FullName));
            photo.applyFilter((Filter) targetFilter);
            return;
        }

        private static void exitFromApp(string message){
            Console.WriteLine(NEW_LINE + message);
            Task.Delay(2000).Wait();
            Environment.Exit(0);
        }

        private static int getInputKey(){
            ConsoleKeyInfo key = Console.ReadKey();
            bool isNumerical = int.TryParse(key.KeyChar.ToString(), out int result);
            if (!isNumerical){
                exitFromApp("You entered not a number");
            }
            return result;
        }

        private static void showFilterList(Type[] allTypesFromFiltersNamespace){
            for (int i = 0;
                 i < allTypesFromFiltersNamespace.Length;
                 i++){
                Type type = allTypesFromFiltersNamespace[i];
                int item = i + 1;
                Console.WriteLine(item + " >> " + type.Name);
            }
        }

        private static Type[] findAllTypesFromFiltersNamespace(){
            return Assembly.GetExecutingAssembly().GetTypes().Where(t => t.Namespace == "Filters").ToArray();
        }
    }
}
