using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание базы данных из 20 сотрудников
            var rep1 = new Repository(20);

            // Печать в консоль всех сотрудников
            rep1.Print(
                "Задание 1. Переделать программу так, чтобы до первой волны увольнени в отделе было не более 20 сотрудников");

            var rep2 = new Repository(40);

            rep2.Print(
                "* Задание 2. Создать отдел из 40 сотрудников и реализовать несколько увольнений, по результатам " +
                "которых в отделе болжно остаться не более 30 работников");

            while (rep2.Workers.Count > 30)
            {
                rep2.DeleteWorkerByName(rep2.Workers[new Random().Next(rep2.Workers.Count)].FirstName);
            }

            rep2.Print("Результат задания 2");

            var rep3 = new Repository(50);

            rep3.Print("** Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников " +
                       "чья зарплата превышает 30000руб");

            while (rep3.Workers.FirstOrDefault(w => w.Salary > 30000) != null)
            {
                rep3.DeleteWorkerBySalary(30000);
            }

            rep3.Print("Результат задания 3");

            Console.ReadLine();

            #region Домашнее задание

            // Уровень сложности: просто
            // Задание 1. Переделать программу так, чтобы до первой волны увольнени в отделе было не более 20 сотрудников

            // Уровень сложности: средняя сложность
            // * Задание 2. Создать отдел из 40 сотрудников и реализовать несколько увольнений, по результатам
            //              которых в отделе болжно остаться не более 30 работников

            // Уровень сложности: сложно
            // ** Задание 3. Создать отдел из 50 сотрудников и реализовать увольнение работников
            //               чья зарплата превышает 30000руб



            #endregion

        }
    }
}
