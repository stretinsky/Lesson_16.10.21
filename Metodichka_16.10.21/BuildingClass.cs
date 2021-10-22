using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Metodichka_16._10._21
{
    class Building
    {
        private Guid id = Guid.NewGuid();
        private double height, floorHeight, apartamentsInEntrance, apartamentsInFloor;
        private short floors, apartaments, entrances;
        public void SetHeight(double height)
        {
            this.height = height;
        }
        public void SetFloors(short floors)
        {
            this.floors = floors;
        }
        public void SetApartaments(short apartaments)
        {
            this.apartaments = apartaments;
        }
        public void SetEntrances(short entrances)
        {
            this.entrances = entrances;
        }
        public void GetBuildingInfo()
        {
            floorHeight = (double)height / floors;
            apartamentsInEntrance = (double)apartaments / entrances;
            apartamentsInFloor = (double)apartaments / floors;
            Console.WriteLine("Дом номер {0}\nКоличество этажей: {1}\nКоличество квартир: {2}\nКоличество подъездов: {3}\nСреднее кол-во квартир на этаже: {4}\nСреднее кол-во квартир в подъезде: {5}\nВысота этажа: {6}", id, floors, apartaments, entrances, apartamentsInFloor, apartamentsInEntrance, floorHeight);
        }
    }
}
