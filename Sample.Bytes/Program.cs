using System.Collections;

byte Bit1 = 0b_1101_1101;
byte Bit2 = 0b_1001_1001;

Console.WriteLine("Val          = " + Convert.ToString(Bit1));
Console.WriteLine("Bit1         = " + Convert.ToString(Bit1, toBase: 2).PadLeft(8, '0'));
Console.WriteLine("Bit2         = " + Convert.ToString(Bit2, toBase: 2).PadLeft(8, '0'));

Console.WriteLine("=========Print value===============");
Console.WriteLine("0b           = " + Convert.ToString(Bit1, toBase: 2).PadLeft(8, '0'));
Console.WriteLine("0b           = " + Convert.ToString(1, toBase: 2).PadLeft(8, '0'));
Console.WriteLine("0x           = " + Convert.ToString(Bit1, toBase: 8));
Console.WriteLine("hex = " + Convert.ToString(Bit1, toBase: 16));

Console.WriteLine("=========Operations===============");
Console.WriteLine("~Bit1        = 0b_" + GetOnlyByte(Convert.ToString(~Bit1, toBase: 2))); //Inverse
Console.WriteLine("Bit1 <<      = 0b_" + GetOnlyByte(Convert.ToString(Bit1 << 1, toBase: 2))); //Left-shift
Console.WriteLine("Bit1 >>      = 0b_" + GetOnlyByte(Convert.ToString(Bit1 >> 1, toBase: 2))); //Right-shift
Console.WriteLine("Bit1 & Bit2  = 0b_" + GetOnlyByte(Convert.ToString(Bit1 & Bit2, toBase: 2))); //AND
Console.WriteLine("Bit1 | Bit2  = 0b_" + GetOnlyByte(Convert.ToString(Bit1 | Bit2, toBase: 2))); //OR
Console.WriteLine("Bit1 ^ Bit2  = 0b_" + GetOnlyByte(Convert.ToString(Bit1 ^ Bit2, toBase: 2))); //Exclusive OR

Console.WriteLine("======ConvertToArray=======");
Console.WriteLine("[]  = [" + string.Join(',', BitConverter.GetBytes((byte) 0b_0000_0001)) + "]");
Console.WriteLine("[]  = [" + string.Join(',', BitConverter.GetBytes(0b_0001_0000)) + "]"); // Default like int

BitArray bitArray = new BitArray(BitConverter.GetBytes((byte) 0b_0001_0000));

for (int i = 0; i < bitArray.Length; i++)
{
    Console.Write($"[{i}]:" + Convert.ToInt16(bitArray[i])  + ",");
}

string GetOnlyByte(string sVal)
{
   string val = sVal.PadLeft(8, '0');
   return val.Substring(val.Length - 8);
}