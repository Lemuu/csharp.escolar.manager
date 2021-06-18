using EscolarManager.Consts;
using EscolarManager.Services.Button;
using System;
using System.Windows.Forms;

namespace EscolarManager.Forms.Management
{
    public partial class FormManagementMain : Form
    {

        private readonly ButtonPanelCollapseService _collapseService;

        public FormManagementMain()
        {
            InitializeComponent();
            this.Text = $"{FormConsts.TextForm} - Geral";
            this._collapseService = new ButtonPanelCollapseService();
        }

        private void FormManagementMain_Load(object sender, EventArgs e)
        {
            this._collapseService.AddPanels(
                this.panelRegister,
                this.panelSearch,
                this.panelUpdate,
                this.panelDelete
            );
        }

        private void buttonPanelRegister_Click(object sender, EventArgs e)
        {
            this._collapseService.Collapse(this.panelRegister);
        }

        private void buttonPanelSearch_Click(object sender, EventArgs e)
        {
            this._collapseService.Collapse(this.panelSearch);
        }

        private void buttonPanelUpdate_Click(object sender, EventArgs e)
        {
            this._collapseService.Collapse(this.panelUpdate);
        }

        private void buttonPanelDelete_Click(object sender, EventArgs e)
        {
            this._collapseService.Collapse(this.panelDelete);
        }
    }
}
