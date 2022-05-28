// Создать игру неа подобии кликерам только чекрез клавиатруру через пробел клик ну и т.п.
// если пользователь убавиет пять мобов то появляетяс босс и скаждым убитым боссом количепсвто дубитых мобов для того чтобы пройти к боссу повышается на один!
// короче идея задорная

using System;
using System.Globalization;
using System.Threading; // для использование sleep

namespace Game_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\t\t\t\t\t\t\t\t\t\t\tSpace_click_killer");
            Console.WriteLine("\nПривет!");
            Console.WriteLine("Это игра кликер, где нажимая на пробел тебе нужно будет убавить мостров мобов и нереально сильных боссов!!!");
            Console.WriteLine("Суть игры я тебе уже объяснил, но повторю еще раз нажимая на пробел ты будешь наносить урон противнику и таким образом победишь его!");
            while (true) // цикл для того чтобы можно было играть в игру постоянно и не перезапускать консоль
            {
                Console.WriteLine("На смену ему придет другой моб, в начале нужно будет убить 5 мобов чтобы пройти к первому боссу, когда ты убьешь первого босса, количетсво убитых мобов для того чтобы пройти к боссу увелисится на один!");
                Console.WriteLine("Выбирай за какой класс ты будешь играть: лучник(урон 75) мечник(урон 150) маг(урон 300. если нажать на enter в место space, то произойдет каст урона в два раза и каст длится 5 секунд)");
                Console.WriteLine("В пиши название класса:");
                string user_class = Console.ReadLine(); // считываем класс пользователя
                switch (user_class) // используем конструкцию switch с параметром пользовательского класс
                {
                    case "лучник": // кейс с строкой лучник, если же пользователь напишет лучник
                        {
                            Console.Clear();
                            uint mobs_health_points = 1000; // здоровье мобов
                            uint user_damage_bow = 75; // урон лучника
                            uint boss_helth_points = 2500; // здоровье босса
                            uint mob_count = 0; // количество убитых мобов
                            Console.WriteLine("Нажмите на space и игра начнеться!");
                            while (true) // цикл для того чтобы наша игра не прерывалась и играть можно было сколько захотим
                            {
                                uint cicle_mobs_hp = mobs_health_points; // создаем копию здоровья мобов для цикла
                                uint cicle_boss_hp = boss_helth_points; // создаем копию здоровья боссов для цикла
                                Console.WriteLine("Количество убитых мобов: "+mob_count);
                                uint count_clear = 0; // счетчик для того чтобы отчистить консоль
                                while(cicle_mobs_hp != 0) // цикл уже саомй игры, то есть цикл с условием того что хп моба не равно нулю
                                {
                                    ConsoleKey consolekey = Console.ReadKey().Key; // считываем нажатия на клавиши пользователем с клавиатуры
                                    //Console.WriteLine(consolekey); // spacebar
                                    switch (consolekey) // используем конструкцию switch и в параметрах указываем переменную, еоторая считывает нажатия пользователя на клавиши на клавиатуре
                                    {
                                        case ConsoleKey.Spacebar: // кейс с вариацией того что пользователь нажмет на клавишу space
                                            {
                                                Console.WriteLine("Здоровье моба:" + cicle_mobs_hp);
                                                if (cicle_mobs_hp > user_damage_bow) // проверка того что хп моба больше урона игрока
                                                {
                                                    cicle_mobs_hp -= user_damage_bow; // типа наносим урон нашим лучником мобу
                                                }
                                                else // если же хп моба меньше хм игрока
                                                {
                                                    cicle_mobs_hp -= cicle_mobs_hp; // то отнимаем хп моба от хп моба (потому что если мы будем отнимать урон лучника то произойдет баг с хм моба) 
                                                }
                                                Console.WriteLine("Удар/-/|-[]");
                                                if (mob_count == 5) // проверка что количество убитых мобов равно 5
                                                {
                                                    int count_clear_for_boss = 0;
                                                    while (cicle_boss_hp != 0) // тоже самое но теперь для хп босса
                                                    {
                                                        ConsoleKey consolekey_for_boss = Console.ReadKey().Key;
                                                        switch (consolekey_for_boss)
                                                        {
                                                            case ConsoleKey.Spacebar:
                                                                {
                                                                    Console.WriteLine("Здоровье босса:" + cicle_boss_hp);
                                                                    cicle_boss_hp -= user_damage_bow;
                                                                    Console.WriteLine("Удар/-/|-[]");
                                                                    break;
                                                                }
                                                        }
                                                        count_clear_for_boss += 1;
                                                        if (count_clear_for_boss % 3 == 0)
                                                        {
                                                            Console.Clear(); // чистим консоль от прошлых сообщений и т.д.
                                                        }
                                                        Thread.Sleep(400); // таймер сна
                                                    }

                                                }
                                                Thread.Sleep(350);
                                                count_clear += 1; // добавляем переменной count_clear единицу
                                                if (count_clear % 3 == 0) // проряем что остаток от деления переменной на три равен нулю
                                                {
                                                    Console.Clear(); // слбственно подчищаем консоль от старых сообщений
                                                }
                                                break;
                                            }
                                        default: // значение по умолчанию
                                            Console.WriteLine("Я не знаю такого удара!!!!");
                                            break;
                                    }
                                    
                                }
                                Console.Clear();
                                Console.WriteLine("Следующий моб!");
                                mobs_health_points +=250; // после того как выполнился цикл с убийством моба (то есть с хп) добавляем мобу 250 хп
                                boss_helth_points += 1000; // ну и также добавляем хп нашему боссу, просто так
                                mob_count += 1; // увеличиваем количесвто убитых мобов на единицу
                                if (mob_count == 5) // проверяем что количество убитых мобов равняется пяти
                                {
                                    Console.WriteLine("Хотите ли вы прододжить играть?");
                                    string user_choice_from_game = Console.ReadLine(); // даем пользователю ввести данные
                                    if (user_choice_from_game == "да" || user_choice_from_game == "yes" || user_choice_from_game == "ДА" || user_choice_from_game == "YES") // проверем что пользователь ввел да
                                    { // если это так, то продолжаем играть
                                        continue;
                                    }
                                    else // иначе прощаемся с пользователем и выходим из цикла и завершаем игру
                                    {
                                        Console.WriteLine("GOOD BYE!!!");
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    case "мечник":
                        {
                            Console.Clear();
                            uint mobs_health_points = 1000;
                            uint user_damage_sword = 150;
                            uint boss_helth_points = 2500;
                            uint mob_count = 0;
                            Console.WriteLine("Нажмите на space и игра начнеться!");
                            while (true)
                            {
                                uint cicle_mobs_hp = mobs_health_points;
                                uint cicle_boss_hp = boss_helth_points;
                                Console.WriteLine("Количество убитых мобов: " + mob_count);
                                uint count_clear = 0;
                                while (cicle_mobs_hp != 0)
                                {
                                    ConsoleKey consolekey = Console.ReadKey().Key;
                                    //Console.WriteLine(consolekey); // spacebar
                                    switch (consolekey)
                                    {
                                        case ConsoleKey.Spacebar:
                                            {
                                                Console.WriteLine("Здоровье моба:" + cicle_mobs_hp);
                                                if (cicle_mobs_hp > user_damage_sword)
                                                {
                                                    cicle_mobs_hp -= user_damage_sword;
                                                }
                                                else
                                                {
                                                    cicle_mobs_hp -= cicle_mobs_hp;
                                                }
                                                Console.WriteLine("Удар/-/|-[]");
                                                if (mob_count % 5 == 0)
                                                {
                                                    int count_clear_for_boss = 0;
                                                    while (cicle_boss_hp != 0)
                                                    {
                                                        ConsoleKey consolekey_for_boss = Console.ReadKey().Key;
                                                        switch (consolekey_for_boss)
                                                        {
                                                            case ConsoleKey.Spacebar:
                                                                {
                                                                    Console.WriteLine("Здоровье босса:" + cicle_boss_hp);
                                                                    cicle_boss_hp -= user_damage_sword;
                                                                    Console.WriteLine("Удар/-/|-[]");
                                                                    break;
                                                                }
                                                        }
                                                        count_clear_for_boss += 1;
                                                        if (count_clear_for_boss % 3 == 0)
                                                        {
                                                            Console.Clear();
                                                        }
                                                        Thread.Sleep(600); // тайм слипер, чтобы когда до этой команды доьралось выполнение работа нашего кода приастановилось на какое-то количество милисекунд
                                                    }

                                                }
                                                Thread.Sleep(450);
                                                count_clear += 1;
                                                if (count_clear % 3 == 0)
                                                {
                                                    Console.Clear();
                                                }
                                                break;
                                            }
                                        default:
                                            Console.WriteLine("Я не знаю такого удара!!!!");
                                            break;
                                    }

                                }
                                Console.Clear();
                                Console.WriteLine("Следующий моб!");
                                mobs_health_points += 250;
                                boss_helth_points += 1000;
                                mob_count += 1;
                                if (mob_count == 5)
                                {
                                    Console.WriteLine("Хотите ли вы прододжить играть?");
                                    string user_choice_from_game = Console.ReadLine();
                                    if (user_choice_from_game == "да" || user_choice_from_game == "yes" || user_choice_from_game == "ДА" || user_choice_from_game == "YES")
                                    {
                                        continue;
                                    }
                                    else
                                    {
                                        Console.WriteLine("GOOD BYE!!!");
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    case "маг":
                        {
                            Console.Clear();
                            Console.WriteLine("Перед начало скажу, если вы нажмете на Enter произойдет каст мощного удара, но после этого вы его не сможете использовать пока не убьете 5 мобов");
                            Console.WriteLine("По этому используйте его с умом!!");
                            uint mob_heath_points = 1000;
                            uint user_damage_magic = 300;
                            uint boss_heath_points = 2500;
                            uint mob_count = 0;
                            Thread.Sleep(8000);
                            Console.Clear();
                            Console.WriteLine("Нажмите space для того чтобы начать играть!");

                            while (true)
                            {
                                uint cicle_mob_hp = mob_heath_points;
                                uint cicle_boss_hp = boss_heath_points;
                                Console.WriteLine("Количество убитых мобов: " + mob_count);
                                uint count_clear = 0;
                                while (cicle_mob_hp != 0)
                                {
                                    ConsoleKey consoleKey = Console.ReadKey().Key;
                                    switch (consoleKey)
                                    {
                                        case ConsoleKey.Enter:
                                            {
                                                if (mob_count == 5)
                                                {
                                                    Console.WriteLine("Здоровье моба: " + cicle_mob_hp);
                                                    if (cicle_mob_hp > (user_damage_magic * 2))
                                                    {
                                                        cicle_mob_hp -= (user_damage_magic * 2);
                                                        Console.WriteLine("Удар/-/|-[]");

                                                    }
                                                    else
                                                    {
                                                        cicle_mob_hp -= cicle_mob_hp;
                                                        Console.WriteLine("Удар/-/|-[]");
                                                    }
                                                    if (mob_count == 5)
                                                    {
                                                        int count_clear_for_boss = 0;
                                                        while (cicle_boss_hp != 0)
                                                        {
                                                            ConsoleKey consolekey_for_boss = Console.ReadKey().Key;
                                                            switch (consolekey_for_boss)
                                                            {
                                                                case ConsoleKey.Enter:
                                                                    {
                                                                        Console.WriteLine("Здоровье босса:" + cicle_boss_hp);
                                                                        if (cicle_boss_hp > user_damage_magic * 2)
                                                                        {
                                                                            cicle_boss_hp -= user_damage_magic * 2;
                                                                            Console.WriteLine("Удар/-/|-[]");
                                                                        }
                                                                        else
                                                                        {
                                                                            cicle_boss_hp -= cicle_boss_hp;
                                                                            Console.WriteLine("Удар/-/|-[]");
                                                                            Console.WriteLine("Удар/-/|-[]");
                                                                            Console.WriteLine("Ура!!!\n\nВы победили босса!!!!\n\nИ так на очереди опять мобы!");
                                                                            Thread.Sleep(2000);

                                                                        }
                                                                        break;
                                                                    }
                                                            }
                                                            count_clear_for_boss += 1;
                                                            if (count_clear_for_boss % 3 == 0)
                                                            {
                                                                Console.Clear();
                                                            }
                                                            Thread.Sleep(600);
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    Console.WriteLine("Вы не убили пять мобов чтобы использовать этот скилл!!!");
                                                    continue;
                                                }
                                                Thread.Sleep(2000);
                                                Console.Clear();
                                                break;
                                            }
                                        case ConsoleKey.Spacebar:
                                            {

                                                Console.WriteLine("Здоровье моба:" + cicle_mob_hp);
                                                if (cicle_mob_hp > user_damage_magic)
                                                {
                                                    cicle_mob_hp -= user_damage_magic;
                                                    Console.WriteLine("Удар/-/|-[]");
                                                }
                                                else
                                                {
                                                    cicle_mob_hp -= cicle_mob_hp;
                                                    Console.WriteLine("Удар/-/|-[]");
                                                }
                                                
                                                if (mob_count == 5)
                                                {
                                                    int count_clear_for_boss = 0;
                                                    while (cicle_boss_hp != 0)
                                                    {
                                                        ConsoleKey consolekey_for_boss = Console.ReadKey().Key;
                                                        switch (consolekey_for_boss)
                                                        {
                                                            case ConsoleKey.Spacebar:
                                                                {
                                                                    Console.WriteLine("Здоровье босса:" + cicle_boss_hp);
                                                                    if (cicle_boss_hp > user_damage_magic)
                                                                    {
                                                                        cicle_boss_hp -= user_damage_magic;
                                                                        Console.WriteLine("Удар/-/|-[]");
                                                                    }
                                                                    else
                                                                    {
                                                                        cicle_boss_hp -= cicle_boss_hp;
                                                                        Console.WriteLine("Удар/-/|-[]");
                                                                        Console.WriteLine("Ура!!!\n\nВы победили босса!!!!\n\nИ так на очереди опять мобы!");
                                                                        Thread.Sleep(2000);
                                                                    }
                                                                    break;
                                                                }
                                                        }
                                                        count_clear_for_boss += 1;
                                                        if (count_clear_for_boss % 3 == 0)
                                                        {
                                                            Console.Clear();
                                                        }
                                                        Thread.Sleep(600); // тайм слипер, чтобы когда до этой команды доьралось выполнение работа нашего кода приастановилось на какое-то количество милисекунд
                                                    }

                                                }
                                                Thread.Sleep(450);
                                                count_clear += 1;
                                                if (count_clear % 3 == 0)
                                                {
                                                    Console.Clear();
                                                }
                                                break;
                                            }
                                        default:
                                            {
                                                Console.WriteLine("УПС!");
                                                Console.WriteLine("Вы не туда нажали, для того чтобы произвести атаку нажмите space или enter");
                                                break;
                                            }
                                    }
                                }
                                mob_heath_points += 250;
                                boss_heath_points += 1000;
                                mob_count += 1;
                                if (mob_count == 5)
                                {
                                    Console.WriteLine("Хотите ли вы продолжить игру?");
                                    Console.WriteLine("Введите да или нет: ");
                                    string user_chois_for_exit = Console.ReadLine();
                                    if (user_chois_for_exit == "да")
                                    {
                                        Console.WriteLine("Хорошо!");
                                        continue;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Спасибо за то, что поиграли в мою игру!");
                                        Console.WriteLine("Надеюсь мы вновь увидимся!");
                                        Console.WriteLine("Удачи!");
                                        break;
                                    }
                                }
                            }
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            Console.WriteLine("Error!!!");
                            Console.WriteLine("Вы ввели не известный мне класс!!!!!");
                            break;                            
                        }
                }
                Console.Clear();
                Console.WriteLine("Хотите ли вы попробывать еще раз?");
                Console.WriteLine("Введите <<да>> или <<нет>>");
                string user_choice = Console.ReadLine();
                if (user_choice == "да"  || user_choice == "yes" || user_choice == "ДА" || user_choice == "YES")
                {
                    continue;
                }
                else
                {
                    Console.WriteLine("GOOD BYE!!!");
                    break;
                }
            }
        }
    }
}