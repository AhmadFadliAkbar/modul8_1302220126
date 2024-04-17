using System;
using System.Text.Json;


	public class BankTransferConfig
	{
        public int nominal_transfer { get; set; }
        public int biaya_transfer { get; set; }
        public int total_biaya { get; set;  }
        public string CONFIG1 { get; set; }
        public int CONFIG2 { get; set; }
        public int CONFIG3 { get; set; }
        public int CONFIG4 { get; set; }
        public string CONFIG5 { get; set; }
        public string CONFIG6 { get; set; }
        public string CONFIG7 { get; set; }



        public BankTransferConfig() {}
	}

    public class AplikasiConfig {
        public BankTransferConfig Config;
        private const string filePath = "bank_transfer_config.json";

        public AplikasiConfig() {
            try
            {
                ReadConfigJson();
            }
            catch {
                Default();
                PrintConfig();
            }
        }
        public void Default()
        {
            Config = new BankTransferConfig();

            Config.CONFIG1 = “en”;
            Config.CONFIG2 = 25000000;
            Config.CONFIG3 = 6500;
            Config.CONFIG4 = 15000;
            Config.CONFIG5 = [ “RTO(real - time)”, “SKN”, “RTGS”, “BI FAST” ];
            Config.CONFIG6 = “yes”;
            Config.CONFIG7 = “ya”;
        }
        public void ReadConfigJson() {
            string configDataJson = File.ReadAllText(filePath);
            Config = JsonSerializer.Deserialize<BankTransferConfig>(configDataJson);

        }
        public void PrintConfig() {
            JsonSerializerOptions Option = new JsonSerializerOptions()
            {
                WriteIndented = true
            };
            string output = JsonSerializer.Serialize(Config);
            File.WriteAllText(filePath, output);
        }
    }

