using System;

namespace Facade
{
    class DHCP
    {
        public string ip;
        public bool enable;
        public DHCP()
        {
            enable = false;
        }
        public void power_DHCP()
        {
            enable = true;
        }
        public void Make_IP(bool enable)
        {
            if (enable == true)
            {
                ip = "192.168.1.1";
            }
        }
        public void Check_DHCP()
        {
            if (enable = true && ip.Length != 0) { Console.WriteLine($"DHCP работает! IP: {ip}"); }
        }
    }
    class DNS
    {
        public string dns;
        public bool enable;
        public DNS()
        {
            this.enable = false;
        }
        public void power_DNS()
        {
            enable = true;
        }
        public void Make_DNS(bool enable)
        {
            if (enable == true) { dns = "8.8.8.8";  }
        }
        public void Check_DNS()
        {
            if (enable = true && dns.Length != 0) { Console.WriteLine($"DNS работает! DNS: {dns}"); }
        }
    }
    class FTP
    {
        public bool enable;
        public FTP()
        {
            this.enable = false;
        }
        public void Power_FTP()
        {
            enable = true;
        }
        public void Send_File(Information file)
        {
            if (file.ping_check == true)
            {
                Console.WriteLine("Файлы отправлены");
            }
        }
        public void Check_FTP()
        {
            if (enable == true) { Console.WriteLine("FTP работает!"); }
        }
    }
    class SSH
    {
        public bool enable;
        public SSH()
        {
            this.enable = false;
        }
        public void Power_SSH()
        {
            enable = true;
        }
        public void Secret(Information file)
        {
            file.file = "Шифрованная информация";
        }
        public void Check_SSH()
        {
            if (enable == true) { Console.WriteLine("SSH работает!"); }
        }
    }
    class Information
    {
        public bool ping_check;
        public string file;
        public Information()
        {
            this.ping_check = false;
            this.file = "Информация";
        }
        public void Ping()
        {
            ping_check = true;
        }

    }
    class ISP
    {
        DHCP dhcp = new DHCP();
        DNS dns = new DNS();
        FTP ftp = new FTP();
        SSH ssh = new SSH();
        Information file = new Information();
        public void Power_Internet()
        {
            dhcp.power_DHCP();
            dhcp.Make_IP(dhcp.enable);
            dns.power_DNS();
            dns.Make_DNS(dns.enable);
            ftp.Power_FTP();
            ssh.Power_SSH();
            Console.WriteLine("Все включено, добро пожаловать в интернет");
        }
        public void Check_internet()
        {
            dhcp.Check_DHCP();
            dns.Check_DNS();
            ftp.Check_FTP();
            ssh.Check_SSH();
        }
        public void Send_File()
        {
            file.Ping();
            ssh.Secret(file);
            ftp.Send_File(file);
            Console.WriteLine($"Файл: {file.file.ToString()}");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            ISP isp = new ISP();
            isp.Power_Internet();
            isp.Check_internet();
            isp.Send_File();
        }
    }
}
