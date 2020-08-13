using ankoPlugin2;
using LibAnko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ankoVoiceChanger
{
    public class Class1 : IPlugin
    {
        private IPluginHost _host = null;
        private static readonly string name = "ボイスチェンジャー";
        private static readonly string version = "0.0.1";

        public string Name { get { return name + version; } }

        public string Description { get { return "コテハンで読み上げの声を切り替えます"; } }

        /**
         * アンコちゃんからホストをもらう
         */
        public IPluginHost host
        {
            get { return this._host; }
            set {
                this._host = value;
                _host.ReceiveChat += _host_ReceiveChat;
            }
        }

        private void _host_ReceiveChat(object sender, ReceiveChatEventArgs e)
        {
            if (_host.CurrentCast == null)
                return;

            chat chat = e.Chat;
            string profname = chat.ProfName;
            // 名前の末尾が整数ならメッセージの頭に記号をつけて読み上げの声を変更する
            // 設定ファイル読み書き
            // https://github.com/TORISOUP/anko2MikuMikuMouth/blob/294db8b1d16c78a9b21bc6fc6f81237b349a7073/src/anko2SpeechMiku/SettingForm.cs
            // 新しいものだとアプリケーション構成ファイルを使うらしい
            // 設定ファイルのパス名
            // Path.Combine(_host.ApplicationDataFolder, this.GetType().Namespace + ".xml");
            // {[読み上げソフト番号:{}, ...],[{記号, 読み上げソフト番号}, ...]}
        }

        public bool IsAlive { get { return false; } }

        public void Run()
        {
        }
        
    }
}
