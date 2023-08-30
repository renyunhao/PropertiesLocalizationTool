namespace ARPDTranslateTool
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            columnHeader4 = new ColumnHeader();
            listViewTarget = new ListView();
            columnHeader3 = new ColumnHeader();
            contextMenuStripRevertChange = new ContextMenuStrip(components);
            ToolStripMenuItemRevert = new ToolStripMenuItem();
            labelTargetFilePath = new Label();
            buttonProcess = new Button();
            radioButtonProcessResult = new RadioButton();
            radioButtonMissing = new RadioButton();
            radioButtonDelete = new RadioButton();
            buttonSave = new Button();
            columnHeader2 = new ColumnHeader();
            listViewSource = new ListView();
            columnHeader1 = new ColumnHeader();
            textBoxKey = new TextBox();
            label2 = new Label();
            label4 = new Label();
            textBoxTargetValue = new TextBox();
            textBoxSourceValue = new TextBox();
            label5 = new Label();
            buttonSaveItem = new Button();
            buttonTranslateSource = new Button();
            splitContainer1 = new SplitContainer();
            labelDragSourceTip = new Label();
            labelSource = new Label();
            buttonChooseSource = new Button();
            labelSourceFilePath = new Label();
            buttonChooseTarget = new Button();
            labelDragTargetTip = new Label();
            labelTarget = new Label();
            textBoxTranslateRef = new TextBox();
            label6 = new Label();
            textBoxSearch = new TextBox();
            label7 = new Label();
            radioButtonUnTranslate = new RadioButton();
            buttonCopyKey = new Button();
            buttonUseTranslated = new Button();
            checkBoxAutoTranslateSource = new CheckBox();
            openFileDialog = new OpenFileDialog();
            label1 = new Label();
            radioButtonSearchKey = new RadioButton();
            radioButtonChanged = new RadioButton();
            buttonClear = new Button();
            labelTransalteState = new Label();
            buttonManualSearch = new Button();
            checkBoxAutoSearch = new CheckBox();
            numericUpDownAutoSearchDelay = new NumericUpDown();
            labelAutoSearchDelay = new Label();
            contextMenuStripRevertChange.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownAutoSearchDelay).BeginInit();
            SuspendLayout();
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Value";
            columnHeader4.Width = 400;
            // 
            // listViewTarget
            // 
            listViewTarget.AllowDrop = true;
            listViewTarget.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewTarget.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            listViewTarget.ContextMenuStrip = contextMenuStripRevertChange;
            listViewTarget.FullRowSelect = true;
            listViewTarget.GridLines = true;
            listViewTarget.LabelWrap = false;
            listViewTarget.Location = new Point(0, 30);
            listViewTarget.MultiSelect = false;
            listViewTarget.Name = "listViewTarget";
            listViewTarget.ShowGroups = false;
            listViewTarget.Size = new Size(450, 472);
            listViewTarget.TabIndex = 12;
            listViewTarget.UseCompatibleStateImageBehavior = false;
            listViewTarget.View = View.Details;
            listViewTarget.SelectedIndexChanged += listViewTarget_SelectedIndexChanged;
            listViewTarget.DragDrop += listViewTarget_DragDrop;
            listViewTarget.DragEnter += listViewTarget_DragEnter;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Index";
            columnHeader3.Width = 80;
            // 
            // contextMenuStripRevertChange
            // 
            contextMenuStripRevertChange.ImageScalingSize = new Size(20, 20);
            contextMenuStripRevertChange.Items.AddRange(new ToolStripItem[] { ToolStripMenuItemRevert });
            contextMenuStripRevertChange.Name = "contextMenuStripRevertChange";
            contextMenuStripRevertChange.Size = new Size(139, 28);
            contextMenuStripRevertChange.Opening += contextMenuStripRevertChange_Opening;
            // 
            // ToolStripMenuItemRevert
            // 
            ToolStripMenuItemRevert.Name = "ToolStripMenuItemRevert";
            ToolStripMenuItemRevert.Size = new Size(138, 24);
            ToolStripMenuItemRevert.Text = "还原修改";
            ToolStripMenuItemRevert.Click += ToolStripMenuItemRevert_Click;
            // 
            // labelTargetFilePath
            // 
            labelTargetFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelTargetFilePath.Location = new Point(82, 2);
            labelTargetFilePath.Name = "labelTargetFilePath";
            labelTargetFilePath.Size = new Size(266, 25);
            labelTargetFilePath.TabIndex = 27;
            labelTargetFilePath.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // buttonProcess
            // 
            buttonProcess.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            buttonProcess.BackColor = SystemColors.Control;
            buttonProcess.Location = new Point(921, 470);
            buttonProcess.Name = "buttonProcess";
            buttonProcess.Size = new Size(186, 311);
            buttonProcess.TabIndex = 15;
            buttonProcess.Text = "一键处理\r\n说明：这个操作会将翻译语言进行重新排序，\r\n与源文对齐，\r\n添加原文多出字串，\r\n删除翻译多出字串\r\n\r\n!!!该操作会直接修改并保存翻译语言的文件!!!\r\n\r\n\r\n";
            buttonProcess.UseVisualStyleBackColor = false;
            buttonProcess.Click += buttonProcess_Click;
            // 
            // radioButtonProcessResult
            // 
            radioButtonProcessResult.AutoSize = true;
            radioButtonProcessResult.Checked = true;
            radioButtonProcessResult.Location = new Point(85, 410);
            radioButtonProcessResult.Name = "radioButtonProcessResult";
            radioButtonProcessResult.Size = new Size(120, 24);
            radioButtonProcessResult.TabIndex = 16;
            radioButtonProcessResult.TabStop = true;
            radioButtonProcessResult.Text = "所有可用字串";
            radioButtonProcessResult.UseVisualStyleBackColor = true;
            radioButtonProcessResult.CheckedChanged += radioButtonProcessResult_CheckedChanged;
            // 
            // radioButtonMissing
            // 
            radioButtonMissing.AutoSize = true;
            radioButtonMissing.Location = new Point(211, 410);
            radioButtonMissing.Name = "radioButtonMissing";
            radioButtonMissing.Size = new Size(120, 24);
            radioButtonMissing.TabIndex = 17;
            radioButtonMissing.Text = "原文多出字串";
            radioButtonMissing.UseVisualStyleBackColor = true;
            radioButtonMissing.CheckedChanged += radioButtonMissing_CheckedChanged;
            // 
            // radioButtonDelete
            // 
            radioButtonDelete.AutoSize = true;
            radioButtonDelete.Location = new Point(337, 410);
            radioButtonDelete.Name = "radioButtonDelete";
            radioButtonDelete.Size = new Size(120, 24);
            radioButtonDelete.TabIndex = 18;
            radioButtonDelete.Text = "翻译多出字串";
            radioButtonDelete.UseVisualStyleBackColor = true;
            radioButtonDelete.CheckedChanged += radioButtonDelete_CheckedChanged;
            // 
            // buttonSave
            // 
            buttonSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonSave.Location = new Point(921, 875);
            buttonSave.Name = "buttonSave";
            buttonSave.Size = new Size(186, 67);
            buttonSave.TabIndex = 20;
            buttonSave.Text = "保存文件";
            buttonSave.UseVisualStyleBackColor = true;
            buttonSave.Click += buttonSave_Click;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Key";
            columnHeader2.Width = 400;
            // 
            // listViewSource
            // 
            listViewSource.AllowDrop = true;
            listViewSource.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            listViewSource.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewSource.ContextMenuStrip = contextMenuStripRevertChange;
            listViewSource.FullRowSelect = true;
            listViewSource.GridLines = true;
            listViewSource.LabelWrap = false;
            listViewSource.Location = new Point(0, 30);
            listViewSource.MultiSelect = false;
            listViewSource.Name = "listViewSource";
            listViewSource.ShowGroups = false;
            listViewSource.Size = new Size(449, 472);
            listViewSource.TabIndex = 11;
            listViewSource.UseCompatibleStateImageBehavior = false;
            listViewSource.View = View.Details;
            listViewSource.SelectedIndexChanged += listViewSource_SelectedIndexChanged;
            listViewSource.DragDrop += listViewSource_DragDrop;
            listViewSource.DragEnter += listViewSource_DragEnter;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Index";
            columnHeader1.Width = 80;
            // 
            // textBoxKey
            // 
            textBoxKey.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxKey.Location = new Point(95, 4);
            textBoxKey.Name = "textBoxKey";
            textBoxKey.ReadOnly = true;
            textBoxKey.Size = new Size(822, 27);
            textBoxKey.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(8, 7);
            label2.Name = "label2";
            label2.Size = new Size(36, 20);
            label2.TabIndex = 21;
            label2.Text = "Key";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(8, 238);
            label4.Name = "label4";
            label4.Size = new Size(39, 20);
            label4.TabIndex = 24;
            label4.Text = "目标";
            // 
            // textBoxTargetValue
            // 
            textBoxTargetValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTargetValue.Font = new Font("Microsoft YaHei UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxTargetValue.Location = new Point(93, 235);
            textBoxTargetValue.Multiline = true;
            textBoxTargetValue.Name = "textBoxTargetValue";
            textBoxTargetValue.ScrollBars = ScrollBars.Vertical;
            textBoxTargetValue.Size = new Size(822, 137);
            textBoxTargetValue.TabIndex = 7;
            textBoxTargetValue.TextChanged += textBoxTargetValue_TextChanged;
            textBoxTargetValue.Leave += textBoxTargetValue_Leave;
            // 
            // textBoxSourceValue
            // 
            textBoxSourceValue.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSourceValue.Font = new Font("Microsoft YaHei UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxSourceValue.Location = new Point(95, 33);
            textBoxSourceValue.Multiline = true;
            textBoxSourceValue.Name = "textBoxSourceValue";
            textBoxSourceValue.ReadOnly = true;
            textBoxSourceValue.ScrollBars = ScrollBars.Vertical;
            textBoxSourceValue.Size = new Size(822, 137);
            textBoxSourceValue.TabIndex = 3;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(8, 36);
            label5.Name = "label5";
            label5.Size = new Size(39, 20);
            label5.TabIndex = 22;
            label5.Text = "源文";
            // 
            // buttonSaveItem
            // 
            buttonSaveItem.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonSaveItem.Enabled = false;
            buttonSaveItem.Location = new Point(923, 235);
            buttonSaveItem.Name = "buttonSaveItem";
            buttonSaveItem.Size = new Size(190, 137);
            buttonSaveItem.TabIndex = 9;
            buttonSaveItem.Text = "保存修改";
            buttonSaveItem.UseVisualStyleBackColor = true;
            buttonSaveItem.Click += buttonSaveItem_Click;
            // 
            // buttonTranslateSource
            // 
            buttonTranslateSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonTranslateSource.Location = new Point(923, 34);
            buttonTranslateSource.Name = "buttonTranslateSource";
            buttonTranslateSource.Size = new Size(190, 29);
            buttonTranslateSource.TabIndex = 4;
            buttonTranslateSource.Text = "翻译源文";
            buttonTranslateSource.UseVisualStyleBackColor = true;
            buttonTranslateSource.Click += buttonTranslateSource_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            splitContainer1.Location = new Point(12, 440);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(labelDragSourceTip);
            splitContainer1.Panel1.Controls.Add(labelSource);
            splitContainer1.Panel1.Controls.Add(buttonChooseSource);
            splitContainer1.Panel1.Controls.Add(listViewSource);
            splitContainer1.Panel1.Controls.Add(labelSourceFilePath);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(buttonChooseTarget);
            splitContainer1.Panel2.Controls.Add(labelDragTargetTip);
            splitContainer1.Panel2.Controls.Add(labelTarget);
            splitContainer1.Panel2.Controls.Add(listViewTarget);
            splitContainer1.Panel2.Controls.Add(labelTargetFilePath);
            splitContainer1.Size = new Size(903, 502);
            splitContainer1.SplitterDistance = 449;
            splitContainer1.TabIndex = 28;
            // 
            // labelDragSourceTip
            // 
            labelDragSourceTip.Location = new Point(83, 202);
            labelDragSourceTip.Name = "labelDragSourceTip";
            labelDragSourceTip.Size = new Size(296, 25);
            labelDragSourceTip.TabIndex = 30;
            labelDragSourceTip.Text = "将语言文件(.properties格式)拖拽至此框内";
            labelDragSourceTip.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelSource
            // 
            labelSource.AutoEllipsis = true;
            labelSource.Location = new Point(3, 3);
            labelSource.Name = "labelSource";
            labelSource.Size = new Size(74, 25);
            labelSource.TabIndex = 28;
            labelSource.Text = "原文语言";
            labelSource.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonChooseSource
            // 
            buttonChooseSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonChooseSource.Location = new Point(353, 1);
            buttonChooseSource.Name = "buttonChooseSource";
            buttonChooseSource.Size = new Size(94, 29);
            buttonChooseSource.TabIndex = 27;
            buttonChooseSource.Text = "导入文件";
            buttonChooseSource.UseVisualStyleBackColor = true;
            buttonChooseSource.Click += buttonChooseSource_Click;
            // 
            // labelSourceFilePath
            // 
            labelSourceFilePath.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            labelSourceFilePath.AutoEllipsis = true;
            labelSourceFilePath.Location = new Point(83, 2);
            labelSourceFilePath.Name = "labelSourceFilePath";
            labelSourceFilePath.Size = new Size(264, 25);
            labelSourceFilePath.TabIndex = 26;
            labelSourceFilePath.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // buttonChooseTarget
            // 
            buttonChooseTarget.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonChooseTarget.Location = new Point(354, 1);
            buttonChooseTarget.Name = "buttonChooseTarget";
            buttonChooseTarget.Size = new Size(94, 29);
            buttonChooseTarget.TabIndex = 29;
            buttonChooseTarget.Text = "导入文件";
            buttonChooseTarget.UseVisualStyleBackColor = true;
            buttonChooseTarget.Click += buttonChooseTarget_Click;
            // 
            // labelDragTargetTip
            // 
            labelDragTargetTip.AutoEllipsis = true;
            labelDragTargetTip.Location = new Point(82, 202);
            labelDragTargetTip.Name = "labelDragTargetTip";
            labelDragTargetTip.Size = new Size(297, 25);
            labelDragTargetTip.TabIndex = 29;
            labelDragTargetTip.Text = "将语言文件(.properties格式)拖拽至此框内";
            labelDragTargetTip.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // labelTarget
            // 
            labelTarget.AutoEllipsis = true;
            labelTarget.Location = new Point(-1, 3);
            labelTarget.Name = "labelTarget";
            labelTarget.Size = new Size(74, 25);
            labelTarget.TabIndex = 29;
            labelTarget.Text = "翻译语言";
            labelTarget.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // textBoxTranslateRef
            // 
            textBoxTranslateRef.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTranslateRef.Location = new Point(95, 178);
            textBoxTranslateRef.Multiline = true;
            textBoxTranslateRef.Name = "textBoxTranslateRef";
            textBoxTranslateRef.ReadOnly = true;
            textBoxTranslateRef.ScrollBars = ScrollBars.Vertical;
            textBoxTranslateRef.Size = new Size(822, 51);
            textBoxTranslateRef.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(8, 182);
            label6.Name = "label6";
            label6.Size = new Size(69, 20);
            label6.TabIndex = 23;
            label6.Text = "翻译参考";
            // 
            // textBoxSearch
            // 
            textBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxSearch.Location = new Point(95, 378);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(511, 27);
            textBoxSearch.TabIndex = 10;
            textBoxSearch.TextChanged += textBoxSearch_TextChanged;
            textBoxSearch.KeyPress += textBoxSearch_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(8, 382);
            label7.Name = "label7";
            label7.Size = new Size(76, 20);
            label7.TabIndex = 25;
            label7.Text = "搜索(Key)";
            // 
            // radioButtonUnTranslate
            // 
            radioButtonUnTranslate.AutoSize = true;
            radioButtonUnTranslate.Location = new Point(463, 410);
            radioButtonUnTranslate.Name = "radioButtonUnTranslate";
            radioButtonUnTranslate.Size = new Size(105, 24);
            radioButtonUnTranslate.TabIndex = 19;
            radioButtonUnTranslate.Text = "未翻译字串";
            radioButtonUnTranslate.UseVisualStyleBackColor = true;
            radioButtonUnTranslate.CheckedChanged += radioButtonUnTranslate_CheckedChanged;
            // 
            // buttonCopyKey
            // 
            buttonCopyKey.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonCopyKey.Location = new Point(923, 4);
            buttonCopyKey.Name = "buttonCopyKey";
            buttonCopyKey.Size = new Size(190, 29);
            buttonCopyKey.TabIndex = 2;
            buttonCopyKey.Text = "复制Key文本";
            buttonCopyKey.UseVisualStyleBackColor = true;
            buttonCopyKey.Click += buttonCopyKey_Click;
            // 
            // buttonUseTranslated
            // 
            buttonUseTranslated.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonUseTranslated.Location = new Point(923, 179);
            buttonUseTranslated.Name = "buttonUseTranslated";
            buttonUseTranslated.Size = new Size(190, 50);
            buttonUseTranslated.TabIndex = 6;
            buttonUseTranslated.Text = "使用翻译";
            buttonUseTranslated.UseVisualStyleBackColor = true;
            buttonUseTranslated.Click += buttonUseTranslated_Click;
            // 
            // checkBoxAutoTranslateSource
            // 
            checkBoxAutoTranslateSource.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxAutoTranslateSource.AutoSize = true;
            checkBoxAutoTranslateSource.Location = new Point(926, 146);
            checkBoxAutoTranslateSource.Name = "checkBoxAutoTranslateSource";
            checkBoxAutoTranslateSource.Size = new Size(121, 24);
            checkBoxAutoTranslateSource.TabIndex = 13;
            checkBoxAutoTranslateSource.Text = "自动翻译源文";
            checkBoxAutoTranslateSource.UseVisualStyleBackColor = true;
            // 
            // openFileDialog
            // 
            openFileDialog.Filter = "“文本文件(*.properties)|*.properties|所有文件(*.*)|*.*” ";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(8, 412);
            label1.Name = "label1";
            label1.Size = new Size(39, 20);
            label1.TabIndex = 29;
            label1.Text = "筛选";
            // 
            // radioButtonSearchKey
            // 
            radioButtonSearchKey.AutoSize = true;
            radioButtonSearchKey.Enabled = false;
            radioButtonSearchKey.Location = new Point(685, 410);
            radioButtonSearchKey.Name = "radioButtonSearchKey";
            radioButtonSearchKey.Size = new Size(90, 24);
            radioButtonSearchKey.TabIndex = 30;
            radioButtonSearchKey.Text = "搜索结果";
            radioButtonSearchKey.UseVisualStyleBackColor = true;
            // 
            // radioButtonChanged
            // 
            radioButtonChanged.AutoSize = true;
            radioButtonChanged.Location = new Point(574, 410);
            radioButtonChanged.Name = "radioButtonChanged";
            radioButtonChanged.Size = new Size(105, 24);
            radioButtonChanged.TabIndex = 31;
            radioButtonChanged.Text = "查看已改动";
            radioButtonChanged.UseVisualStyleBackColor = true;
            radioButtonChanged.CheckedChanged += radioButtonChanged_CheckedChanged;
            // 
            // buttonClear
            // 
            buttonClear.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonClear.Location = new Point(921, 802);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(186, 67);
            buttonClear.TabIndex = 32;
            buttonClear.Text = "清理全部";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // labelTransalteState
            // 
            labelTransalteState.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelTransalteState.Location = new Point(923, 66);
            labelTransalteState.Name = "labelTransalteState";
            labelTransalteState.Size = new Size(190, 77);
            labelTransalteState.TabIndex = 33;
            // 
            // buttonManualSearch
            // 
            buttonManualSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            buttonManualSearch.Location = new Point(819, 377);
            buttonManualSearch.Name = "buttonManualSearch";
            buttonManualSearch.Size = new Size(94, 29);
            buttonManualSearch.TabIndex = 30;
            buttonManualSearch.Text = "手动搜索";
            buttonManualSearch.UseVisualStyleBackColor = true;
            buttonManualSearch.Click += buttonManualSearch_Click;
            // 
            // checkBoxAutoSearch
            // 
            checkBoxAutoSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            checkBoxAutoSearch.AutoSize = true;
            checkBoxAutoSearch.Checked = true;
            checkBoxAutoSearch.CheckState = CheckState.Checked;
            checkBoxAutoSearch.Location = new Point(612, 379);
            checkBoxAutoSearch.Name = "checkBoxAutoSearch";
            checkBoxAutoSearch.Size = new Size(91, 24);
            checkBoxAutoSearch.TabIndex = 34;
            checkBoxAutoSearch.Text = "自动搜索";
            checkBoxAutoSearch.UseVisualStyleBackColor = true;
            // 
            // numericUpDownAutoSearchDelay
            // 
            numericUpDownAutoSearchDelay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            numericUpDownAutoSearchDelay.DecimalPlaces = 1;
            numericUpDownAutoSearchDelay.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownAutoSearchDelay.Location = new Point(752, 378);
            numericUpDownAutoSearchDelay.Name = "numericUpDownAutoSearchDelay";
            numericUpDownAutoSearchDelay.Size = new Size(61, 27);
            numericUpDownAutoSearchDelay.TabIndex = 35;
            numericUpDownAutoSearchDelay.Value = new decimal(new int[] { 15, 0, 0, 65536 });
            // 
            // labelAutoSearchDelay
            // 
            labelAutoSearchDelay.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            labelAutoSearchDelay.AutoSize = true;
            labelAutoSearchDelay.Location = new Point(709, 381);
            labelAutoSearchDelay.Name = "labelAutoSearchDelay";
            labelAutoSearchDelay.Size = new Size(39, 20);
            labelAutoSearchDelay.TabIndex = 36;
            labelAutoSearchDelay.Text = "延迟";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1119, 954);
            Controls.Add(labelAutoSearchDelay);
            Controls.Add(numericUpDownAutoSearchDelay);
            Controls.Add(checkBoxAutoSearch);
            Controls.Add(buttonManualSearch);
            Controls.Add(labelTransalteState);
            Controls.Add(buttonClear);
            Controls.Add(radioButtonChanged);
            Controls.Add(radioButtonSearchKey);
            Controls.Add(label1);
            Controls.Add(checkBoxAutoTranslateSource);
            Controls.Add(splitContainer1);
            Controls.Add(buttonUseTranslated);
            Controls.Add(buttonCopyKey);
            Controls.Add(buttonTranslateSource);
            Controls.Add(buttonSaveItem);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label2);
            Controls.Add(textBoxSourceValue);
            Controls.Add(textBoxTargetValue);
            Controls.Add(textBoxSearch);
            Controls.Add(textBoxTranslateRef);
            Controls.Add(textBoxKey);
            Controls.Add(buttonSave);
            Controls.Add(radioButtonUnTranslate);
            Controls.Add(radioButtonDelete);
            Controls.Add(radioButtonMissing);
            Controls.Add(radioButtonProcessResult);
            Controls.Add(buttonProcess);
            HelpButton = true;
            MinimumSize = new Size(1137, 897);
            Name = "MainForm";
            Text = "properties本地化辅助工具-作者：renyunhao";
            FormClosing += MainForm_FormClosing;
            contextMenuStripRevertChange.ResumeLayout(false);
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)numericUpDownAutoSearchDelay).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private ColumnHeader columnHeader4;
        private ListView listViewTarget;
        private Label labelTargetFilePath;
        private Button buttonProcess;
        private RadioButton radioButtonProcessResult;
        private RadioButton radioButtonMissing;
        private RadioButton radioButtonDelete;
        private Button buttonSave;
        private ColumnHeader columnHeader2;
        private ListView listViewSource;
        private TextBox textBoxKey;
        private Label label2;
        private Label label4;
        private TextBox textBoxTargetValue;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader3;
        private TextBox textBoxSourceValue;
        private Label label5;
        private Button buttonSaveItem;
        private Button buttonTranslateSource;
        private SplitContainer splitContainer1;
        private TextBox textBoxTranslateRef;
        private Label label6;
        private TextBox textBoxSearch;
        private Label label7;
        private RadioButton radioButtonUnTranslate;
        private Button buttonCopyKey;
        private Button buttonUseTranslated;
        private CheckBox checkBoxAutoTranslateSource;
        private Label labelDragSourceTip;
        private Label labelSource;
        private Button buttonChooseSource;
        private Label labelSourceFilePath;
        private Button buttonChooseTarget;
        private Label labelDragTargetTip;
        private Label labelTarget;
        private OpenFileDialog openFileDialog;
        private Label label1;
        private RadioButton radioButtonSearchKey;
        private RadioButton radioButtonChanged;
        private Button buttonClear;
        private Label labelTransalteState;
        private ContextMenuStrip contextMenuStripRevertChange;
        private ToolStripMenuItem ToolStripMenuItemRevert;
        private Button buttonManualSearch;
        private CheckBox checkBoxAutoSearch;
        private NumericUpDown numericUpDownAutoSearchDelay;
        private Label labelAutoSearchDelay;
    }
}