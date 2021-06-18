using System.Collections.Generic;
using Panel = System.Windows.Forms.Panel;

namespace EscolarManager.Services.Button
{
    class ButtonPanelCollapseService
    {
        private IDictionary<Panel, bool> Panels;

        public ButtonPanelCollapseService()
        {
            Panels = new Dictionary<Panel, bool>();
        }

        public void AddPanels(params Panel[] panels)
        {
            foreach (var panel in panels)
            {
                Panels.Add(panel, false);
                MinimumSize(panel);
            }
        }

        public void Collapse(Panel panel)
        {
            if (!Panels.ContainsKey(panel))
            {
                Panels.Add(panel, false);
            }

            if (IsCollapsed(panel))
            {
                MinimumSize(panel);
                return;
            }
            MaximumSize(panel);
        }

        private bool IsCollapsed(Panel panel)
        {
            return Panels.ContainsKey(panel) && Panels[panel];
        }

        private void MinimumSize(Panel panel)
        {
            panel.Size = panel.MinimumSize;
            Panels[panel] = false;
        }

        private void MaximumSize(Panel panel)
        {
            panel.Size = panel.MaximumSize;
            Panels[panel] = true;
        }

    }
}
