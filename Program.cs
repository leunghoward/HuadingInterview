using System.Collections;
using System.Text.RegularExpressions;


//我使用的是vs2022 .net6.0的版本

#region 初始化三行火柴的数量
string str = "cc";
; ; ; ArrayList arrayList1 = new ArrayList();int b = 2;
ArrayList arrayList2 = new ArrayList();
ArrayList arrayList3 = new ArrayList();

for (int i = 0; i < 3; i++)
{
    arrayList1.Add("h");
}

for (int i = 0; i < 5; i++)
{
    arrayList2.Add("h");
}

for (int i = 0; i < 7; i++)
{
    arrayList3.Add("h");
}
#endregion

int leftOver = 15; //剩余火柴总数量

ArrayList arrayListA = new ArrayList(); //A玩家拿的火柴总数量
ArrayList arrayListB = new ArrayList(); //B玩家拿的火柴总数量

do
{
    Console.WriteLine("输入玩家账号：A/B");
    string player = Console.ReadLine();
    while (!IsA_Z(player))
    {
        Console.WriteLine("非字母，请重新输入。");
        player = Console.ReadLine();
    }
    

    string line = "";
    string number = "";
    if (player.ToUpper() == "A")
    {
        try
        {
            Console.WriteLine("现在剩余每行的火柴数量：" + "第一行:" + arrayList1.Count + " 第二行:" + arrayList2.Count + " 第三行:" + arrayList3.Count);

            Console.WriteLine("请拿火柴，数量不限，但不能跨行，请输入行号(阿拉伯数字)");
            line = Console.ReadLine();
            while (!IsNum(line))
            {
                Console.WriteLine("非数字,请重新输入。");
                line = Console.ReadLine();
            }

            Console.WriteLine("请输入拿火柴的根数(阿拉伯数字)");
            number = Console.ReadLine();
            while (!IsNum(number))
            {
                Console.WriteLine("非数字,请重新输入。");
                number = Console.ReadLine();
            }

            CommonMethod(arrayList1, arrayList2, arrayList3, ref line, ref number);

            if (int.Parse(line) != 1 && int.Parse(line) != 2 && int.Parse(line) != 3)
            {
                Console.WriteLine("没有此行号");
                continue;
            }


            leftOver -= int.Parse(number);  //减去A玩家每次拿的火柴数量得出剩余火柴总数量
            int tempNumber = int.Parse(number);
            while (tempNumber > 0)  //记录A玩家拿的火柴累计总数量
            {
                arrayListA.Add("h");
                tempNumber-- ;
            }
            if (leftOver == 0)
            {
                Console.WriteLine("A拿了最后一根火柴，输了游戏");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    if (player.ToUpper() == "B")
    {
        try
        {
            Console.WriteLine("现在剩余每行的火柴数量：" + "第一行:" + arrayList1.Count + " 第二行:" + arrayList2.Count + " 第三行:" + arrayList3.Count);

            Console.WriteLine("请拿火柴，数量不限，但不能跨行，请输入行号(阿拉伯数字)");
            line = Console.ReadLine();
            while (!IsNum(line))
            {
                Console.WriteLine("非数字,请重新输入。");
                line = Console.ReadLine();
            }

            Console.WriteLine("请输入拿火柴的根数(阿拉伯数字)");
            number = Console.ReadLine();
            while (!IsNum(number))
            {
                Console.WriteLine("非数字,请重新输入。");
                number = Console.ReadLine();
            }

            CommonMethod(arrayList1, arrayList2, arrayList3, ref line, ref number);

            if (int.Parse(line) != 1 && int.Parse(line) != 2 && int.Parse(line) != 3)
            {
                Console.WriteLine("没有此行号");
                continue;
            }


            leftOver -= int.Parse(number);
            int tempNumber = int.Parse(number);
            while (tempNumber > 0)
            {
                arrayListB.Add("h");
                tempNumber--;
            }
            if (leftOver == 0)
            {
                Console.WriteLine("B拿了最后一根火柴，输了游戏");
            }
        }
        catch (Exception ex)
        {

            throw ex;
        }

    }

    if (player.ToUpper() != "A" && player.ToUpper() != "B")
    {
        Console.WriteLine("没有此玩家");
        continue;
    }

} while (leftOver > 0);


static bool IsNum(string s)  //正则表达式判断输入是否是数字
{
    return Regex.IsMatch(s, @"^\d+");
}

static bool IsA_Z(string s) //正则表达式判断输入是否是字母
{
    return Regex.IsMatch(s, @"^[A-Za-z]+$");
}

static void CommonMethod(ArrayList arrayList1, ArrayList arrayList2, ArrayList arrayList3, ref string line, ref string number)
{
    if (int.Parse(line) == 1)
    {
        if (arrayList1.Count == 0)
        {
            while (int.Parse(line) == 1)
            {
                Console.WriteLine("第一行根数为0，不能拿，请换行拿，请重新输入行号");
                line = Console.ReadLine();
                while (!IsNum(line))
                {
                    Console.WriteLine("非数字,请重新输入。");
                    line = Console.ReadLine();
                }
            }

        }
        if (int.Parse(number) > arrayList1.Count)
        {
            while (int.Parse(number) > arrayList1.Count)
            {
                Console.WriteLine("拿取数量大于剩余数量，请重取");
                number = Console.ReadLine();
                while (!IsNum(number))
                {
                    Console.WriteLine("非数字,请重新输入。");
                    number = Console.ReadLine();
                }
            }
        }
        if (!(arrayList1.Count == 0)  && !(int.Parse(number) > arrayList1.Count) ) //第一行根数不为零且此次拿取的火柴数量少于第一行的火柴当前剩余数量是，玩家才算拿取成功，算入玩家的拿取总根数里
        {
            for (int i = 0; i < int.Parse(number); i++)
            {
                arrayList1.Remove("h");
            }
        }
    }
    if (int.Parse(line) == 2)
    {
        if (arrayList2.Count == 0)
        {
            while (int.Parse(line) == 2)
            {
                Console.WriteLine("第二行根数为0，不能拿，请换行拿，请重新输入行号（阿拉伯数字）");
                line = Console.ReadLine();
                while (!IsNum(line))
                {
                    Console.WriteLine("非数字,请重新输入。");
                    line = Console.ReadLine();
                }
            }

        }
        if (int.Parse(number) > arrayList2.Count)
        {
            while (int.Parse(number) > arrayList2.Count)
            {
                Console.WriteLine("拿取数量大于剩余数量，请重取");
                number = Console.ReadLine();
                while (!IsNum(number))
                {
                    Console.WriteLine("非数字,请重新输入。");
                    number = Console.ReadLine();
                }
            }

        }
        if (!(arrayList2.Count == 0)  && !(int.Parse(number) > arrayList2.Count) )
        {
            for (int i = 0; i < int.Parse(number); i++)
            {
                arrayList2.Remove("h");
            }
        }
    }
    if (int.Parse(line) == 3)
    {
        if (arrayList3.Count == 0)
        {
            while (int.Parse(line) == 3)
            {
                Console.WriteLine("第三行根数为0，不能拿，请换行拿，请重新输入行号（阿拉伯数字）");
                line = Console.ReadLine();
                while (!IsNum(line))
                {
                    Console.WriteLine("非数字,请重新输入。");
                    line = Console.ReadLine();
                }
            }

        }
        if (int.Parse(number) > arrayList3.Count)
        {
            while (int.Parse(number) > arrayList3.Count)
            {
                Console.WriteLine("拿取数量大于剩余数量，请重取");
                number = Console.ReadLine();
                while (!IsNum(number))
                {
                    Console.WriteLine("非数字,请重新输入。");
                    number = Console.ReadLine();
                }
            }

        }
        if (!(arrayList3.Count == 0)  && !(int.Parse(number) > arrayList3.Count) )
        {
            for (int i = 0; i < int.Parse(number); i++)
            {
                arrayList3.Remove("h");
            }
        }
    }
}