using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RocketLeague.utils;
using System.IO;
using System.Windows.Controls;
using System.Windows;

namespace RocketLeague
{
    class ReplayParser
    {
        MainWindow window;
        public int readedBytes = 0;

        public string last = "";

        public int team0score = 0;
        public int team1score = 0;
        public int teamsize;

        public Player[] playerList;

        public string[] team1;
        public string[] team2;

        public int status = 0;
        public int playerNb = 0;

        public int unfair = 0;

        public void setPlayers()
        {
            int j = 0;
            int k = 0;
            for (int i = 0; i < playerList.Length; i++)
            {
                if (playerList[i].team == 0)
                    team1[j++] = playerList[i].Name;
                if (playerList[i].team == 1)
                    team2[k++] = playerList[i].Name;
            }

            for (int i = 0; i < team1.Length; i++)
            {
                if (i == 0)
                    window.t1p1.Text = team1[i];
                if (i == 1)
                    window.t1p2.Text = team1[i];
                if (i == 2)
                    window.t1p3.Text = team1[i];
                if (i == 3)
                    window.t1p4.Text = team1[i];
            }
            for (int i = 0; i < team2.Length; i++)
            {
                if (i == 0)
                    window.t2p1.Text = team2[i];
                if (i == 1)
                    window.t2p2.Text = team2[i];
                if (i == 2)
                    window.t2p3.Text = team2[i];
                if (i == 3)
                    window.t2p4.Text = team2[i];
            }

            if (playerNb / 2 + unfair == 1)
            {
                window.t1p2.Text = "";
                window.t1p3.Text = "";
                window.t1p4.Text = "";
                window.t2p2.Text = "";
                window.t2p3.Text = "";
                window.t2p4.Text = "";

                window.t1p2S.Text = "";
                window.t1p3S.Text = "";
                window.t1p4S.Text = "";
                window.t2p2S.Text = "";
                window.t2p3S.Text = "";
                window.t2p4S.Text = "";
            }
            else if (playerNb / 2 + unfair == 2)
            {
                window.t1p3.Text = "";
                window.t1p4.Text = "";
                window.t2p3.Text = "";
                window.t2p4.Text = "";

                window.t1p3S.Text = "";
                window.t1p4S.Text = "";
                window.t2p3S.Text = "";
                window.t2p4S.Text = "";
            }
            else if (playerNb / 2 + unfair == 3)
            {
                window.t1p4.Text = "";
                window.t2p4.Text = "";
                window.t1p4S.Text = "";
                window.t2p4S.Text = "";
            }
        }

        public void setStats()
        {
            for (int i = 0; i < playerList.Length; i++)
            {
                if (window.t1p1.Text != "" && window.t1p1.Text == playerList[i].Name)
                {
                    window.t1p1S.Text = playerList[i].score.ToString();
                    window.t1p1G.Text = playerList[i].goals.ToString();
                    window.t1p1A.Text = playerList[i].assists.ToString();
                    window.t1p1Sa.Text = playerList[i].saves.ToString();
                    window.t1p1Sh.Text = playerList[i].saves.ToString();
                }
                else if (window.t1p1.Text == "")
                {
                    window.t1p1S.Text = "";
                    window.t1p1G.Text = "";
                    window.t1p1A.Text = "";
                    window.t1p1Sa.Text = "";
                    window.t1p1Sh.Text = "";
                }

                if (window.t1p2.Text != "" && window.t1p2.Text == playerList[i].Name)
                { 
                    window.t1p2S.Text = playerList[i].score.ToString();
                    window.t1p2G.Text = playerList[i].goals.ToString();
                    window.t1p2A.Text = playerList[i].assists.ToString();
                    window.t1p2Sa.Text = playerList[i].saves.ToString();
                    window.t1p2Sh.Text = playerList[i].saves.ToString();
                }
                else if (window.t1p2.Text == "")
                { 
                    window.t1p2S.Text = "";
                    window.t1p2G.Text = "";
                    window.t1p2A.Text = "";
                    window.t1p2Sa.Text = "";
                    window.t1p2Sh.Text = "";
                }

                if (window.t1p3.Text != "" && window.t1p3.Text == playerList[i].Name)
                { 
                    window.t1p3S.Text = playerList[i].score.ToString();
                    window.t1p3G.Text = playerList[i].goals.ToString();
                    window.t1p3A.Text = playerList[i].assists.ToString();
                    window.t1p3Sa.Text = playerList[i].saves.ToString();
                    window.t1p3Sh.Text = playerList[i].saves.ToString();
                }
                else if (window.t1p3.Text == "")
                { 
                    window.t1p3S.Text = "";
                    window.t1p3G.Text = "";
                    window.t1p3A.Text = "";
                    window.t1p3Sa.Text = "";
                    window.t1p3Sh.Text = "";
                }

                if (window.t1p4.Text != "" && window.t1p4.Text == playerList[i].Name)
                { 
                    window.t1p4S.Text = playerList[i].score.ToString();
                    window.t1p4G.Text = playerList[i].goals.ToString();
                    window.t1p4A.Text = playerList[i].assists.ToString();
                    window.t1p4Sa.Text = playerList[i].saves.ToString();
                    window.t1p4Sh.Text = playerList[i].saves.ToString();
                }
                else if (window.t1p4.Text == "")
                { 
                    window.t1p4S.Text = "";
                    window.t1p4G.Text = "";
                    window.t1p4A.Text = "";
                    window.t1p4Sa.Text = "";
                    window.t1p4Sh.Text = "";
                }

                if (window.t2p1.Text != "" && window.t2p1.Text == playerList[i].Name)
                { 
                    window.t2p1S.Text = playerList[i].score.ToString();
                    window.t2p1G.Text = playerList[i].goals.ToString();
                    window.t2p1A.Text = playerList[i].assists.ToString();
                    window.t2p1Sa.Text = playerList[i].saves.ToString();
                    window.t2p1Sh.Text = playerList[i].saves.ToString();
                }
                else if (window.t2p1.Text == "")
                { 
                    window.t2p1S.Text = "";
                    window.t2p1G.Text = "";
                    window.t2p1A.Text = "";
                    window.t2p1Sa.Text = "";
                    window.t2p1Sh.Text = "";
                }

                if (window.t2p2.Text != "" && window.t2p2.Text == playerList[i].Name)
                { 
                    window.t2p2S.Text = playerList[i].score.ToString();
                    window.t2p2G.Text = playerList[i].goals.ToString();
                    window.t2p2A.Text = playerList[i].assists.ToString();
                    window.t2p2Sa.Text = playerList[i].saves.ToString();
                    window.t2p2Sh.Text = playerList[i].saves.ToString();
                }
                else if (window.t2p2.Text == "")
                { 
                    window.t2p2S.Text = "";
                    window.t2p2G.Text = "";
                    window.t2p2A.Text = "";
                    window.t2p2Sa.Text = "";
                    window.t2p2Sh.Text = "";
                }

                if (window.t2p3.Text != "" && window.t2p3.Text == playerList[i].Name)
                { 
                    window.t2p3S.Text = playerList[i].score.ToString();
                    window.t2p3G.Text = playerList[i].goals.ToString();
                    window.t2p3A.Text = playerList[i].assists.ToString();
                    window.t2p3Sa.Text = playerList[i].saves.ToString();
                    window.t2p3Sh.Text = playerList[i].saves.ToString();
                }
                else if (window.t2p3.Text == "")
                { 
                    window.t2p3S.Text = "";
                    window.t2p3G.Text = "";
                    window.t2p3A.Text = "";
                    window.t2p3Sa.Text = "";
                    window.t2p3Sh.Text = "";
                }

                if (window.t2p4.Text != "" && window.t2p4.Text == playerList[i].Name)
                { 
                    window.t2p4S.Text = playerList[i].score.ToString();
                    window.t2p4G.Text = playerList[i].goals.ToString();
                    window.t2p4A.Text = playerList[i].assists.ToString();
                    window.t2p4Sa.Text = playerList[i].saves.ToString();
                    window.t2p4Sh.Text = playerList[i].saves.ToString();
                }
                else if (window.t2p4.Text == "")
                { 
                    window.t2p4S.Text = "";
                    window.t2p4G.Text = "";
                    window.t2p4A.Text = "";
                    window.t2p4Sa.Text = "";
                    window.t2p4Sh.Text = "";
                }
            }
        }

        public void setAll()
        {
            window.team0score.Text = team0score.ToString();
            window.team1score.Text = team1score.ToString();
            window.teamsize.Text = teamsize.ToString() + "v" + teamsize.ToString();

            if (playerNb % 2 != 0)
                unfair = 1;
            team1 = new string[playerNb / 2 + unfair];
            team2 = new string[playerNb / 2 + unfair];

            setPlayers();
            setStats();
        }

        public void updateValues(int value)
        {
            if (last == "TeamSize")
                teamsize = value;
            else if (last == "Team0Score")
                team0score = value;
            else if (last == "Team1Score")
                team1score = value;
            else if (last == "PlayerStats")
            {
                status = 1;
                playerList = new Player[value];
                for (int i = 0; i < value; i++)
                    playerList[i] = new Player();
            }
            else if (last == "Team" && status == 1)
                playerList[playerNb].team = value;
            else if (last == "Score" && status == 1)
                playerList[playerNb].score = value;
            else if (last == "Goals" && status == 1)
                playerList[playerNb].goals = value;
            else if (last == "Assists" && status == 1)
                playerList[playerNb].assists = value;
            else if (last == "Saves" && status == 1)
                playerList[playerNb].saves = value;
            else if (last == "Shots" && status == 1)
                playerList[playerNb].shots = value;
        }

        public void ParseHeader(FileStream fs)
        {
            foreach (Window tmp in Application.Current.Windows)
                if (tmp.GetType() == typeof(MainWindow))
                    this.window = (MainWindow)tmp;

            int value;
            float valueFloat;
            bool IsOrNot;
            int strLen = ConvertTo.GetIntFromStream(fs);
            string tst = ConvertTo.GetStringFromStream(fs, strLen);
            readedBytes += 4;
            readedBytes += strLen;
            ConvertTo.SkipPadding(fs, 1);

            if (status == 1)
            {
                if (last == "None")
                    playerNb++;
                if (last == "Name")
                    playerList[playerNb].Name = tst;
                if (last == "RecordFPS")
                    status = 2;
            }

            if (tst == "IntProperty")
            {
                ConvertTo.GetIntFromStream(fs);
                ConvertTo.GetIntFromStream(fs);
                value = ConvertTo.GetIntFromStream(fs);
                readedBytes += 12;

                updateValues(value);

                last = tst;
                window.txtEditor.Text += tst + " : " + value.ToString() + "\n";
                return;
            }
            else if (tst == "ArrayProperty")
            {
                ConvertTo.GetIntFromStream(fs);
                ConvertTo.GetIntFromStream(fs);
                value = ConvertTo.GetIntFromStream(fs);
                readedBytes += 12;
                window.txtEditor.Text += tst + " : " + value.ToString() + "\n";

                updateValues(value);

                return;
            }
            else if (tst == "StrProperty" || tst == "ByteProperty" || tst == "NameProperty")
            {
                ConvertTo.GetIntFromStream(fs);
                ConvertTo.GetIntFromStream(fs);
                readedBytes += 8;

                return;
            }
            else if (tst == "QWordProperty")
            {
                ConvertTo.GetIntFromStream(fs);
                ConvertTo.GetIntFromStream(fs);
                ConvertTo.GetIntFromStream(fs);
                ConvertTo.GetIntFromStream(fs);
                readedBytes += 16;
            }
            else if (tst == "BoolProperty")
            {
                ConvertTo.GetIntFromStream(fs);
                ConvertTo.GetIntFromStream(fs);
                IsOrNot = ConvertTo.GetBoolFromStream(fs);
                readedBytes += 9;
                window.txtEditor.Text += tst + " : " + IsOrNot.ToString() + "\n";

                if (status == 1)
                    playerList[playerNb].isBot = IsOrNot;

                return;
            }
            else if (tst == "FloatProperty")
            {
                ConvertTo.GetIntFromStream(fs);
                ConvertTo.GetIntFromStream(fs);
                valueFloat = ConvertTo.GetFloatFromStream(fs);
                readedBytes += 12;
                window.txtEditor.Text += tst + " : " + valueFloat.ToString() + "\n";
                return;
            }
            last = tst;
            window.txtEditor.Text += tst + "\n";
        }
    }
}
