using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace RegularExpressionFinder
{
    public partial class RegularExpressionFinder : Form
    {
        public RegularExpressionFinder()
        {
            InitializeComponent();
        }

        //
        // 3.STARTを押したとき
        //
        private void button1_Click(object sender, EventArgs e)
        {
            if (lstTargetFiles.Items.Count < 1 || txtRegularExpressions.Lines.Length < 1)
            {
                MessageBox.Show("検索対象ファイルと正規表現を指定してください");
                return;
            }


            //コントロールを初期化する
            progressBar1.Minimum = 0;
            progressBar1.Maximum = lstTargetFiles.Items.Count-1;
            progressBar1.Value = 0;
            lblStatus.Text = "0";


            // 正規表現一覧表を作成する
            //String lineExpression = "";
            String[] multiExpressions = new String[txtRegularExpressions.Lines.Length];

            StringReader sread = new StringReader(txtRegularExpressions.Text);
            for (int i = 0; i < txtRegularExpressions.Lines.Length; i++)
            {
                multiExpressions[i] = sread.ReadLine();
            }


            // answer.txtの生成
            DateTime dt = DateTime.Now;
            string answerFileName = "answer_" + dt.ToString("yyyyMMddHHmmss") + ".txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.Environment.CurrentDirectory + "\\"+answerFileName, false, System.Text.Encoding.GetEncoding("shift_jis"));
            

            

            //時間のかかる処理を開始する
            //検索対象ファイルを１ファイルずつ読み込む
            for (int i = 0; i < lstTargetFiles.Items.Count; i++)
            {
                StreamReader sr = new System.IO.StreamReader(lblTargetFolder.Text+"\\"+lstTargetFiles.Items[i],System.Text.Encoding.GetEncoding("shift_jis"));
                
                //検索対象を一行ずつ読み込む
                while (sr.Peek() > -1)
                {
                    string lineTarget =sr.ReadLine();

                    //正規表現を１行ずつ取り出す
                    for (int j = 0; j < multiExpressions.Length; j++)
                    {
                        
                        string myMultiExpression = multiExpressions[j];


                        //【墨付きかっこ】でファイル名条件が指定されていたら、ファイル名と分割する。
                        if (myMultiExpression.IndexOf('【') > 0)
                        {
                            int position = myMultiExpression.IndexOf('【')+1;
                            string fileNameRequired = myMultiExpression.Substring(position, myMultiExpression.Length - position-1);
                            myMultiExpression = myMultiExpression.Substring(0, position-1);

                            string fName = lstTargetFiles.Items[i]+"";

                            //MessageBox.Show(fileNameRequired + "/" + fName);
                            
                            if (fName.IndexOf(fileNameRequired) < 0)
                            {
                                //MessageBox.Show(fileNameRequired + " in " + fName + "was not found.");
                                //ファイル名にファイル名条件が含まれていなければ、この正規表現との比較は飛ばす
                                continue;
                            }

                            
                        }



                        // 区切りで分割して配列に格納する
                        string[] myExpressions = myMultiExpression.Split('&');

                        Boolean breaker = false;

                        // 各正規表現と比較していく
                        for (int k = 0; k < myExpressions.Length; k++)
                        {
                            string myExpression = myExpressions[k];

                            System.Text.RegularExpressions.Regex r;
                            try
                            {
                                r = new System.Text.RegularExpressions.Regex(myExpression, System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(myExpression+"　は正規表現として正しくありません");
                                break;
                            }

                            System.Text.RegularExpressions.Match m = r.Match(lineTarget);

                            //マッチしなければ、この正規表現行からはbreak
                            if (m.Success)
                            {
                                
                                
                                if (k == myExpressions.Length - 1)
                                {
                                    //最後までマッチしたら、このlineTargetを保存。
                                    sw.WriteLine("["+lstTargetFiles.Items[i]+"]"+lineTarget);

                                    //このlineTargetについては保存済みなので、他の正規表現行と比較不要
                                    breaker = true;
                                    break;
                                }
                            }
                            else
                            {
                                
                                break;
                            }


                        }

                        if (breaker)
                        {
                            //このlineTargetについては保存済みなので、他の正規表現行と比較不要
                            breaker = false;
                            break;
                        }




                        /*
                        //lineTarget内で正規表現と一致する対象を1つ検索
                        System.Text.RegularExpressions.Regex r =
                         new System.Text.RegularExpressions.Regex(expressions[j],System.Text.RegularExpressions.RegexOptions.IgnoreCase);
                        
                        System.Text.RegularExpressions.Match m = r.Match(lineTarget);

                        if (m.Success)
                        {
                            //MessageBox.Show("MATCH:"+lineTarget);
                            //sw.Write(m.Value+"\r\n");
                            sw.WriteLine(lineTarget);
                        }
                        */
                    }
                }
                //閉じる
                sr.Close();

                //ProgressBar1の値を変更する
                progressBar1.Value = i;

                //Label1のテキストを変更する
                lblStatus.Text = "File:"+lstTargetFiles.Items[i]+"  ("+ i.ToString()+"/"+lstTargetFiles.Items.Count+")";
            }

            //結果を報告する
            lblStatus.Text = "complete";

            //answer.txt閉じる
            sw.Close();

            DialogResult result = MessageBox.Show("結果を "+answerFileName+ " に保存しました。表示しますか?",
                "質問",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (result == DialogResult.Yes)
            {
                //「はい」が選択された時
                // ファイルを指定してメモ帳を起動する
                System.Diagnostics.Process.Start("Notepad", System.Environment.CurrentDirectory + "\\" + answerFileName);
            }


        }

        //
        // 1.Select Folderを押したとき
        //
        private void btnSelectFolder_Click(object sender, EventArgs e)
        {
            //FolderBrowserDialogクラスのインスタンスを作成
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            //上部に表示する説明テキストを指定する
            fbd.Description = "フォルダを指定してください。";
            //ルートフォルダを指定する
            //デフォルトでDesktop
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            //最初に選択するフォルダを指定する
            fbd.SelectedPath = System.Environment.CurrentDirectory+"\\files";
            //ユーザーが新しいフォルダを作成できるようにする
            //デフォルトでTrue
            fbd.ShowNewFolderButton = true;

            //ダイアログを表示する
            if (fbd.ShowDialog(this) == DialogResult.OK)
            {
                //選択されたフォルダを表示する
                lblTargetFolder.Text = fbd.SelectedPath;

                loadTargets();
            }
        }

        //
        // 2.正規表現一覧を押したとき
        //
        private void btnLoadExpression_Click(object sender, EventArgs e)
        {
            //OpenFileDialogクラスのインスタンスを作成
            OpenFileDialog ofd = new OpenFileDialog();

            //はじめのファイル名を指定する
            //はじめに「ファイル名」で表示される文字列を指定する
            ofd.FileName = "expressions.txt";
            //はじめに表示されるフォルダを指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            ofd.InitialDirectory = System.Environment.CurrentDirectory;
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しないとすべてのファイルが表示される
            ofd.Filter =
                "TXTファイル(*.txt)|*.txt|すべてのファイル(*.*)|*.*";
            //[ファイルの種類]ではじめに
            //「すべてのファイル」が選択されているようにする
            ofd.FilterIndex = 2;
            //タイトルを設定する
            ofd.Title = "開くファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            ofd.RestoreDirectory = true;
            //存在しないファイルの名前が指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckFileExists = true;
            //存在しないパスが指定されたとき警告を表示する
            //デフォルトでTrueなので指定する必要はない
            ofd.CheckPathExists = true;

            //ダイアログを表示する
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                //OKボタンがクリックされたとき
                //選択されたファイル名を表示する
                Console.WriteLine(ofd.FileName);

                System.IO.StreamReader sr = new System.IO.StreamReader(ofd.FileName, System.Text.Encoding.GetEncoding("shift_jis"));
                //内容をすべて読み込む
                string s = sr.ReadToEnd();
                //閉じる
                sr.Close();


                txtRegularExpressions.Text = s;
            }



            
        }

        //
        // アプリケーション起動時
        //
        private void RegularExpressionFinder_Load(object sender, EventArgs e)
        {
            // ターゲット一覧を読み込み
            lblTargetFolder.Text = System.Environment.CurrentDirectory + "\\files";

            loadTargets();

            //　正規表現を読み込み
            try { 
                System.IO.StreamReader sr = new System.IO.StreamReader(System.Environment.CurrentDirectory+"\\expressions.txt", System.Text.Encoding.GetEncoding("shift_jis"));
                
                string s = sr.ReadToEnd();
                
                sr.Close();

                txtRegularExpressions.Text = s;
            }catch(Exception ex){

            }


            
        }

        private void loadTargets()
        {
            lstTargetFiles.Items.Clear();

            try
            {
                string[] files = System.IO.Directory.GetFiles(lblTargetFolder.Text, "*", System.IO.SearchOption.AllDirectories);

                for (int i = 0; i < files.Length; i++)
                {
                    files[i] = files[i].Substring(lblTargetFolder.Text.Length + 1);
                }

                //ListBox1に結果を表示する
                lstTargetFiles.Items.AddRange(files);
            }
            catch (Exception ex)
            {

            }
        }
    }
}
