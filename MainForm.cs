using System;
using System.Text;
using System.Windows.Forms;

namespace ARPDTranslateTool
{
    public partial class MainForm : Form
    {
        public class TranslateData
        {
            public Dictionary<string, string> dataDict = new Dictionary<string, string>();//文件的Key和Value
            public List<string> keyList = new List<string>(); //完整的包含了源文件的空行的Key值，空行的Key值为空，注释行的Key值就是注释本身。这个的作用保存翻译文件时，使其结构与源文件完全一一对应，空行对空行，翻译对翻译，正文对正文
            public HashSet<string> missingKey = new HashSet<string>();//源文多出的Key
            public Dictionary<string, string> deleteKeyValue = new Dictionary<string, string>();//翻译多出的Key和Value
            public Dictionary<string, string> changedKeyValue = new Dictionary<string, string>();//修改过的Key和Value，Value是修改前的值
            public HashSet<string> untranslateKey = new HashSet<string>();//未翻译的Key

            public void Clear()
            {
                dataDict.Clear();
                keyList.Clear();
                missingKey.Clear();
                deleteKeyValue.Clear();
                untranslateKey.Clear();
            }

            public void Reset()
            {
                missingKey.Clear();
                deleteKeyValue.Clear();
                untranslateKey.Clear();
            }
        }

        TranslateData sourceData = new TranslateData();
        TranslateData targetData = new TranslateData();

        Dictionary<string, ListViewItem> listViewSourceResultItem = new Dictionary<string, ListViewItem>();
        Dictionary<string, ListViewItem> listViewSourceMissingItem = new Dictionary<string, ListViewItem>();
        Dictionary<string, ListViewItem> listViewSourceDeleteItem = new Dictionary<string, ListViewItem>();
        Dictionary<string, ListViewItem> listViewSourceUntranslateItem = new Dictionary<string, ListViewItem>();

        Dictionary<string, ListViewItem> listViewTargetResultItem = new Dictionary<string, ListViewItem>();
        Dictionary<string, ListViewItem> listViewTargetMissingItem = new Dictionary<string, ListViewItem>();
        Dictionary<string, ListViewItem> listViewTargetDeleteItem = new Dictionary<string, ListViewItem>();
        Dictionary<string, ListViewItem> listViewTargetUntranslateItem = new Dictionary<string, ListViewItem>();

        string sourceFilePath;
        string targetFilePath;

        bool targetItemTextChanged = false;
        bool isClear = true;
        ListViewItem selectedTargetItem;

        HashSet<string> changeKeyList = new HashSet<string>();
        List<string> searchResultKeyList = new List<string>();//搜索结果，是一个Key列表，文本可以通过TranslateData.dataDict来查询
        System.Timers.Timer timer = new System.Timers.Timer();

        public MainForm()
        {
            InitializeComponent();
            buttonProcess.BackColor = SystemColors.Control;
            buttonProcess.Enabled = false;
            buttonTranslateSource.Enabled = false;
            buttonCopyKey.Enabled = false;
            buttonUseTranslated.Enabled = false;
            buttonClear.Enabled = false;
            buttonSave.Enabled = false;
            timer.Elapsed += StartAutoSearch;
        }

        private void Clear()
        {
            sourceData.Clear();
            targetData.Clear();
            listViewSource.BackColor = SystemColors.Window;
            listViewTarget.BackColor = SystemColors.Window;
            isClear = true;
            labelDragSourceTip.Visible = true;
            labelDragTargetTip.Visible = true;

            listViewSource.Items.Clear();
            listViewTarget.Items.Clear();

            buttonSaveItem.Enabled = false;
            checkBoxAutoTranslateSource.Checked = false;
            buttonCopyKey.Enabled = false;
            buttonTranslateSource.Enabled = false;
            buttonUseTranslated.Enabled = false;
            buttonClear.Enabled = false;
            buttonSave.Enabled = false;

            textBoxKey.Text = string.Empty;
            textBoxSearch.Text = string.Empty;
            textBoxSourceValue.Text = string.Empty;
            textBoxTargetValue.Text = string.Empty;
            textBoxTranslateRef.Text = string.Empty;
            labelSourceFilePath.Text = string.Empty;
            labelTargetFilePath.Text = string.Empty;

            listViewSourceResultItem.Clear();
            listViewSourceMissingItem.Clear();
            listViewSourceDeleteItem.Clear();
            listViewSourceUntranslateItem.Clear();

            listViewTargetResultItem.Clear();
            listViewTargetMissingItem.Clear();
            listViewTargetDeleteItem.Clear();
            listViewTargetUntranslateItem.Clear();

            radioButtonProcessResult.Checked = true;
        }

        private void listViewSource_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop) && isClear)
                    e.Effect = DragDropEffects.Link;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void listViewSource_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && isClear)
            {
                var data = e.Data.GetData(DataFormats.FileDrop);
                if (data != null)
                {
                    sourceFilePath = ((string[])data)[0];
                    ProcessSourceFile();
                }
            }
        }

        private void ProcessSourceFile()
        {
            labelSourceFilePath.Text = Path.GetFileName(sourceFilePath);
            string[] fileContent = File.ReadAllLines(sourceFilePath);
            ParseFile(fileContent, sourceData);
            listViewSource.BackColor = Color.GreenYellow;
            RefreshProcessButton();
            labelDragSourceTip.Visible = false;
        }

        private void listViewTarget_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data != null)
            {
                if (e.Data.GetDataPresent(DataFormats.FileDrop) && isClear)
                    e.Effect = DragDropEffects.Link;
                else
                    e.Effect = DragDropEffects.None;
            }
        }

        private void listViewTarget_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data != null && isClear)
            {
                var data = e.Data.GetData(DataFormats.FileDrop);
                if (data != null)
                {
                    targetFilePath = ((string[])data)[0];
                    ProcessTargetFile();
                }
            }
        }

        private void ProcessTargetFile()
        {
            labelTargetFilePath.Text = Path.GetFileName(targetFilePath);
            string[] fileContent = File.ReadAllLines(targetFilePath);
            ParseFile(fileContent, targetData);
            listViewTarget.BackColor = Color.GreenYellow;
            RefreshProcessButton();
            labelDragTargetTip.Visible = false;
        }

        private void RefreshProcessButton()
        {
            bool canProcess = sourceData.dataDict.Count > 0 && targetData.dataDict.Count > 0;
            buttonProcess.BackColor = canProcess ? Color.GreenYellow : SystemColors.Control;
            buttonProcess.Enabled = canProcess;
            radioButtonProcessResult.Enabled = canProcess;
            radioButtonMissing.Enabled = canProcess;
            radioButtonDelete.Enabled = canProcess;
        }

        private void ParseFile(string[] sourceFileContent, TranslateData applyToData)
        {
            buttonClear.Enabled = true;
            try
            {
                applyToData.Clear();
                foreach (var line in sourceFileContent)
                {
                    var trimedLine = line.Trim();
                    if (string.IsNullOrEmpty(trimedLine) || trimedLine.StartsWith("#"))
                    {
                        applyToData.keyList.Add(trimedLine);
                    }
                    else
                    {
                        var splits = trimedLine.Split('=');
                        if (splits.Length != 2)
                        {
                            MessageBox.Show("这一行有问题：" + line);
                        }
                        else
                        {
                            string key = splits[0];
                            string value = splits[1];
                            applyToData.dataDict[key] = value;
                            applyToData.keyList.Add(key);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常：" + ex.ToString());
            }
        }

        private void buttonProcess_Click(object sender, EventArgs e)
        {
            isClear = false;
            targetData.keyList = sourceData.keyList;
            buttonProcess.BackColor = Color.Gray;
            buttonProcess.Enabled = false;
            listViewSource.BackColor = SystemColors.Window;
            listViewTarget.BackColor = SystemColors.Window;

            //处理缺失的项
            foreach (var kvp in sourceData.dataDict)
            {
                if (targetData.dataDict.ContainsKey(kvp.Key) == false)
                {
                    targetData.missingKey.Add(kvp.Key);
                    targetData.dataDict[kvp.Key] = kvp.Value;
                }
            }

            //处理删除的项
            foreach (var kvp in targetData.dataDict)
            {
                if (sourceData.dataDict.ContainsKey(kvp.Key) == false)
                {
                    targetData.deleteKeyValue.Add(kvp.Key, kvp.Value);
                    targetData.keyList.Remove(kvp.Key);
                }
            }

            foreach (var key in targetData.deleteKeyValue.Keys)
            {
                targetData.dataDict.Remove(key);
            }

            //处理未翻译项
            foreach (var kvp in sourceData.dataDict)
            {
                if (targetData.dataDict.ContainsKey(kvp.Key))
                {
                    if (kvp.Value.Equals(targetData.dataDict[kvp.Key]))
                    {
                        targetData.untranslateKey.Add(kvp.Key);
                    }
                }
            }

            //核对数值项是否正确

            if (radioButtonProcessResult.Checked)
            {
                ShowResult();
            }
            else
            {
                radioButtonProcessResult.Checked = true;
            }


            SaveTargetFile();
        }

        private void radioButtonProcessResult_CheckedChanged(object sender, EventArgs e)
        {
            EnableEdit();
            ShowResult();
        }

        private void radioButtonMissing_CheckedChanged(object sender, EventArgs e)
        {
            EnableEdit();
            ShowMissing();
        }

        private void radioButtonDelete_CheckedChanged(object sender, EventArgs e)
        {
            DisableEdit();
            ShowDelete();
        }

        private void radioButtonUnTranslate_CheckedChanged(object sender, EventArgs e)
        {
            EnableEdit();
            ShowUnTranslate();
        }

        private void radioButtonChanged_CheckedChanged(object sender, EventArgs e)
        {
            EnableEdit();
            ShowChange();
        }

        private void DisableEdit()
        {
            buttonTranslateSource.Enabled = false;
            textBoxTargetValue.Enabled = false;
            buttonUseTranslated.Enabled = false;
        }

        public void EnableEdit()
        {
            buttonTranslateSource.Enabled = true;
            textBoxTargetValue.Enabled = true;
        }

        private void ShowResult()
        {
            listViewSource.Items.Clear();
            listViewTarget.Items.Clear();
            if (listViewSourceResultItem.Count == 0)
            {
                int index = 0;
                foreach (var kvp in sourceData.dataDict)
                {
                    var keyItem = new ListViewItem(new string[] { index.ToString(), kvp.Key });
                    keyItem.Name = kvp.Key;
                    listViewSource.Items.Add(keyItem);
                    index++;
                }
                index = 0;
                foreach (var key in targetData.keyList)
                {
                    if (string.IsNullOrEmpty(key)) { continue; }
                    if (key.StartsWith("#")) { continue; }

                    var valueItem = new ListViewItem(new string[] { index.ToString(), targetData.dataDict[key] });
                    valueItem.Name = key;
                    listViewTarget.Items.Add(valueItem);
                    index++;
                }

                foreach (ListViewItem item in listViewSource.Items)
                {
                    listViewSourceResultItem.Add(item.Name, item);
                }

                foreach (ListViewItem item in listViewTarget.Items)
                {
                    listViewTargetResultItem.Add(item.Name, item);
                }
            }
            else
            {
                foreach (ListViewItem item in listViewSourceResultItem.Values)
                {
                    listViewSource.Items.Add(item);
                }

                foreach (ListViewItem item in listViewTargetResultItem.Values)
                {
                    listViewTarget.Items.Add(item);
                }
            }
        }

        private void ShowMissing()
        {
            listViewSource.Items.Clear();
            listViewTarget.Items.Clear();
            if (listViewSourceMissingItem.Count == 0)
            {
                int index = 0;
                foreach (var key in targetData.missingKey)
                {
                    var indexText = index.ToString();

                    var keyItem = new ListViewItem(new string[] { indexText, key });
                    keyItem.Name = key;
                    listViewSource.Items.Add(keyItem);

                    var valueItem = new ListViewItem(new string[] { indexText, targetData.dataDict[key] });
                    valueItem.Name = key;
                    listViewTarget.Items.Add(valueItem);
                    index++;
                }

                foreach (ListViewItem item in listViewSource.Items)
                {
                    listViewSourceMissingItem.Add(item.Name, item);
                }

                foreach (ListViewItem item in listViewTarget.Items)
                {
                    listViewTargetMissingItem.Add(item.Name, item);
                }
            }
            else
            {
                foreach (ListViewItem item in listViewSourceMissingItem.Values)
                {
                    listViewSource.Items.Add(item);
                }

                foreach (ListViewItem item in listViewTargetMissingItem.Values)
                {
                    listViewTarget.Items.Add(item);
                }
            }
        }

        private void ShowDelete()
        {
            listViewSource.Items.Clear();
            listViewTarget.Items.Clear();
            if (listViewSourceDeleteItem.Count == 0)
            {
                int index = 0;
                foreach (var kvp in targetData.deleteKeyValue)
                {
                    var indexText = index.ToString();

                    var keyItem = new ListViewItem(new string[] { indexText, kvp.Key });
                    keyItem.Name = kvp.Key;
                    listViewSource.Items.Add(keyItem);

                    var valueItem = new ListViewItem(new string[] { indexText, kvp.Value });
                    valueItem.Name = kvp.Key;
                    listViewTarget.Items.Add(valueItem);
                    index++;
                }

                foreach (ListViewItem item in listViewSource.Items)
                {
                    listViewSourceDeleteItem.Add(item.Name, item);
                }

                foreach (ListViewItem item in listViewTarget.Items)
                {
                    listViewTargetDeleteItem.Add(item.Name, item);
                }
            }
            else
            {
                foreach (ListViewItem item in listViewSourceDeleteItem.Values)
                {
                    listViewSource.Items.Add(item);
                }

                foreach (ListViewItem item in listViewTargetDeleteItem.Values)
                {
                    listViewTarget.Items.Add(item);
                }
            }
        }

        private void ShowUnTranslate()
        {
            listViewSource.Items.Clear();
            listViewTarget.Items.Clear();
            if (listViewSourceUntranslateItem.Count == 0)
            {
                int index = 0;
                foreach (var key in targetData.untranslateKey)
                {
                    var indexText = index.ToString();

                    var keyItem = new ListViewItem(new string[] { indexText, key });
                    keyItem.Name = key;
                    listViewSource.Items.Add(keyItem);

                    var valueItem = new ListViewItem(new string[] { indexText, targetData.dataDict[key] });
                    valueItem.Name = key;
                    listViewTarget.Items.Add(valueItem);
                    index++;
                }

                foreach (ListViewItem item in listViewSource.Items)
                {
                    listViewSourceUntranslateItem.Add(item.Name, item);
                }

                foreach (ListViewItem item in listViewTarget.Items)
                {
                    listViewTargetUntranslateItem.Add(item.Name, item);
                }
            }
            else
            {
                foreach (ListViewItem item in listViewSourceUntranslateItem.Values)
                {
                    listViewSource.Items.Add(item);
                }

                foreach (ListViewItem item in listViewTargetUntranslateItem.Values)
                {
                    listViewTarget.Items.Add(item);
                }
            }
        }

        private void ShowChange()
        {
            listViewSource.Items.Clear();
            listViewTarget.Items.Clear();
            foreach (string key in changeKeyList)
            {
                if (listViewSourceResultItem.ContainsKey(key))
                {
                    listViewSource.Items.Add(listViewSourceResultItem[key]);
                    listViewTarget.Items.Add(listViewTargetResultItem[key]);
                }
                else if (listViewSourceDeleteItem.ContainsKey(key))
                {
                    listViewSource.Items.Add(listViewSourceDeleteItem[key]);
                    listViewTarget.Items.Add(listViewTargetDeleteItem[key]);
                }
            }
        }

        private void ShowSearchResult()
        {
            listViewSource.Items.Clear();
            listViewTarget.Items.Clear();

            foreach (var key in searchResultKeyList)
            {
                listViewSource.Items.Add(listViewSourceResultItem[key]);
                listViewTarget.Items.Add(listViewTargetResultItem[key]);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (sourceData.dataDict.Count > 0)
            {
                var result = MessageBox.Show("你确定要清理?", "三思而后行", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    Clear();
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("你确定要保存?", "三思而后行", MessageBoxButtons.OKCancel);
            if (result == DialogResult.OK)
            {
                SaveTargetFile();
                MessageBox.Show("保存成功！");
            }
        }

        private void SaveTargetFile()
        {
            StringBuilder sb = new StringBuilder(200000);
            foreach (var key in targetData.keyList)
            {
                if (string.IsNullOrEmpty(key))
                {
                    sb.AppendLine();
                }
                else if (key.StartsWith("#"))
                {
                    sb.AppendLine(key);
                }
                else
                {
                    sb.AppendFormat("{0}={1}", key, targetData.dataDict[key]);
                    sb.AppendLine();
                }
            }
            File.WriteAllText(targetFilePath, sb.ToString());
        }

        private void listViewSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewSource.SelectedItems.Count > 0 && listViewSource.Focused)
            {
                textBoxTranslateRef.Text = string.Empty;
                buttonTranslateSource.Enabled = true;
                buttonCopyKey.Enabled = true;
                buttonUseTranslated.Enabled = false;
                var key = listViewSource.SelectedItems[0].SubItems[1].Text;
                textBoxKey.Text = key;
                if (sourceData.dataDict.ContainsKey(key))
                {
                    textBoxSourceValue.Text = sourceData.dataDict[textBoxKey.Text];
                    textBoxTargetValue.Text = targetData.dataDict[textBoxKey.Text];
                }
                else
                {
                    textBoxSourceValue.Text = targetData.deleteKeyValue[textBoxKey.Text];
                    textBoxTargetValue.Text = targetData.deleteKeyValue[textBoxKey.Text];
                }
                int index = listViewSource.SelectedIndices[0];
                selectedTargetItem = listViewTarget.Items[index];
                selectedTargetItem.Selected = true;
                listViewTarget.EnsureVisible(index);
                AutoTranslateCheck();
            }
        }

        private void listViewTarget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewTarget.SelectedItems.Count > 0 && listViewTarget.Focused)
            {
                textBoxTranslateRef.Text = string.Empty;
                buttonTranslateSource.Enabled = true;
                buttonCopyKey.Enabled = true;
                buttonUseTranslated.Enabled = false;
                selectedTargetItem = listViewTarget.SelectedItems[0];
                var key = selectedTargetItem.Name;
                textBoxKey.Text = key;
                if (sourceData.dataDict.ContainsKey(key))
                {
                    textBoxSourceValue.Text = sourceData.dataDict[textBoxKey.Text];
                    textBoxTargetValue.Text = targetData.dataDict[textBoxKey.Text];
                }
                else
                {
                    textBoxSourceValue.Text = targetData.deleteKeyValue[textBoxKey.Text];
                    textBoxTargetValue.Text = targetData.deleteKeyValue[textBoxKey.Text];
                }
                int index = listViewTarget.SelectedIndices[0];
                listViewSource.Items[index].Selected = true;
                listViewSource.EnsureVisible(index);
                AutoTranslateCheck();
            }
        }

        private void textBoxTargetValue_TextChanged(object sender, EventArgs e)
        {
            if (textBoxTargetValue.Focused)
            {
                targetItemTextChanged = true;
                buttonSaveItem.Enabled = true;
            }
        }

        private void textBoxTargetValue_Leave(object sender, EventArgs e)
        {
            SaveCurrentEditItem();
        }

        private void buttonSaveItem_Click(object sender, EventArgs e)
        {
            SaveCurrentEditItem();
        }

        private void SaveCurrentEditItem()
        {
            if (targetItemTextChanged)
            {
                targetItemTextChanged = false;
                buttonSaveItem.Enabled = false;
                string key = textBoxKey.Text;
                string newValue = textBoxTargetValue.Text;
                if (targetData.changedKeyValue.ContainsKey(key) == false)
                {
                    targetData.changedKeyValue.Add(key, targetData.dataDict[key]);
                }
                targetData.dataDict[key] = newValue;
                if (listViewTargetResultItem.ContainsKey(key))
                {
                    listViewTargetResultItem[key].SubItems[1].Text = newValue;
                    listViewSourceResultItem[key].BackColor = Color.Orange;
                    listViewTargetResultItem[key].BackColor = Color.Orange;
                }
                if (listViewTargetMissingItem.ContainsKey(key))
                {
                    listViewTargetMissingItem[key].SubItems[1].Text = newValue;
                    listViewSourceMissingItem[key].BackColor = Color.Orange;
                    listViewTargetMissingItem[key].BackColor = Color.Orange;
                }
                if (listViewTargetDeleteItem.ContainsKey(key))
                {
                    listViewTargetDeleteItem[key].SubItems[1].Text = newValue;
                    listViewSourceDeleteItem[key].BackColor = Color.Orange;
                    listViewTargetDeleteItem[key].BackColor = Color.Orange;
                }
                if (listViewTargetUntranslateItem.ContainsKey(key))
                {
                    listViewTargetUntranslateItem[key].SubItems[1].Text = newValue;
                    listViewSourceUntranslateItem[key].BackColor = Color.Orange;
                    listViewTargetUntranslateItem[key].BackColor = Color.Orange;
                }

                changeKeyList.Add(key);

                buttonSave.Enabled = true;
            }
        }

        private void buttonCopyKey_Click(object sender, EventArgs e)
        {
            Clipboard.SetDataObject(textBoxKey.Text);
        }

        private void buttonTranslateSource_Click(object sender, EventArgs e)
        {
            TransalteSource();
        }

        private void TransalteSource()
        {
            buttonUseTranslated.Enabled = false;
            labelTransalteState.Text = "翻译中，请稍候...";
            Translator.Translate(textBoxSourceValue.Text, "zh-CN", (succeed, data) =>
            {
                Console.WriteLine(data);
                if (succeed)
                {
                    textBoxTranslateRef.BeginInvoke(() =>
                    {
                        labelTransalteState.Text = "";
                        textBoxTranslateRef.Text = data.resultText;
                        buttonUseTranslated.Enabled = !radioButtonMissing.Checked;
                    });
                }
                else
                {
                    labelTransalteState.BeginInvoke(() =>
                    {
                        labelTransalteState.Text = "翻译失败，请检查网络（确保代理正常工作）或原文是否属于可翻译内容";
                    });
                }
            }, textBoxKey.Text);
        }

        private void buttonTranslateTarget_Click(object sender, EventArgs e)
        {
            TranslateTarget();
        }

        private void TranslateTarget()
        {
            Translator.Translate(textBoxTargetValue.Text, "zh-CN", (succeed, data) =>
            {
                Console.WriteLine(data);
                if (succeed)
                {
                    textBoxTranslateRef.BeginInvoke(() =>
                    {
                        textBoxTranslateRef.Text = data.resultText;
                    });
                }
            }, textBoxKey.Text);
        }

        private void buttonUseTranslated_Click(object sender, EventArgs e)
        {
            textBoxTargetValue.Text = textBoxTranslateRef.Text;
            targetItemTextChanged = true;
            buttonSaveItem.Enabled = true;
        }

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                timer.Stop();
                SearchKey(textBoxSearch.Text);
            }
        }

        private void SearchKey(string text)
        {
            searchResultKeyList.Clear();
            radioButtonSearchKey.Checked = true;
            foreach (ListViewItem item in listViewSourceResultItem.Values)
            {
                var keyItem = item.SubItems[1];
                if (keyItem.Text.Contains(text))
                {
                    searchResultKeyList.Add(keyItem.Text);
                }
            }
            EnableEdit();
            ShowSearchResult();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxSearch.Text) == false && checkBoxAutoSearch.Checked)
            {
                timer.Stop();
                timer.Interval = ((double)numericUpDownAutoSearchDelay.Value * 1000);
                timer.Start();
            }
        }

        private void StartAutoSearch(object? sender, System.Timers.ElapsedEventArgs e)
        {
            timer.Stop();
            textBoxSearch.BeginInvoke(() =>
            {
                SearchKey(textBoxSearch.Text);
            });
        }

        private void AutoTranslateCheck()
        {
            if (checkBoxAutoTranslateSource.Checked && radioButtonMissing.Checked == false)
            {
                TransalteSource();
            }
        }

        private void buttonChooseSource_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                sourceFilePath = openFileDialog.FileName;
                ProcessSourceFile();
            }
        }

        private void buttonChooseTarget_Click(object sender, EventArgs e)
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                targetFilePath = openFileDialog.FileName;
                ProcessTargetFile();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (sourceData.dataDict.Count > 0)
            {
                var result = MessageBox.Show("你确定要关闭?", "三思而后行", MessageBoxButtons.OKCancel);
                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        private void ToolStripMenuItemRevert_Click(object sender, EventArgs e)
        {
            string key = string.Empty;
            if (listViewSource.Focused)
            {
                if (listViewSource.SelectedItems.Count == 0)
                {
                    return;
                }
                key = listViewSource.SelectedItems[0].SubItems[1].Text;
            }
            else if (listViewTarget.Focused)
            {
                if (listViewTarget.SelectedItems.Count == 0)
                {
                    return;
                }
                key = listViewTarget.SelectedItems[0].Name;
            }

            if (targetData.changedKeyValue.TryGetValue(key, out var oldValue))
            {
                targetData.dataDict[key] = oldValue;
                if (listViewTargetResultItem.ContainsKey(key))
                {
                    listViewTargetResultItem[key].SubItems[1].Text = oldValue;
                    listViewSourceResultItem[key].BackColor = Color.White;
                    listViewTargetResultItem[key].BackColor = Color.White;
                }
                if (listViewTargetMissingItem.ContainsKey(key))
                {
                    listViewTargetMissingItem[key].SubItems[1].Text = oldValue;
                    listViewSourceMissingItem[key].BackColor = Color.White;
                    listViewTargetMissingItem[key].BackColor = Color.White;
                }
                if (listViewTargetDeleteItem.ContainsKey(key))
                {
                    listViewTargetDeleteItem[key].SubItems[1].Text = oldValue;
                    listViewSourceDeleteItem[key].BackColor = Color.White;
                    listViewTargetDeleteItem[key].BackColor = Color.White;
                }
                if (listViewTargetUntranslateItem.ContainsKey(key))
                {
                    listViewTargetUntranslateItem[key].SubItems[1].Text = oldValue;
                    listViewSourceUntranslateItem[key].BackColor = Color.White;
                    listViewTargetUntranslateItem[key].BackColor = Color.White;
                }

                //删除本次修改过的项
                changeKeyList.Remove(key);
                if (radioButtonChanged.Checked)
                {
                    ShowChange();
                }
            }
        }

        private void contextMenuStripRevertChange_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            string key = string.Empty;
            if (listViewSource.Focused)
            {
                if (listViewSource.SelectedItems.Count == 0)
                {
                    e.Cancel = true;
                    return;
                }
                key = listViewSource.SelectedItems[0].SubItems[1].Text;
            }
            else if (listViewTarget.Focused)
            {
                if (listViewTarget.SelectedItems.Count == 0)
                {
                    e.Cancel = true;
                    return;
                }
                key = listViewTarget.SelectedItems[0].Name;
            }

            if (changeKeyList.Contains(key) == false)
            {
                e.Cancel = true;
            }
        }

        private void buttonManualSearch_Click(object sender, EventArgs e)
        {
            timer.Stop();
            SearchKey(textBoxSearch.Text);
        }
    }
}