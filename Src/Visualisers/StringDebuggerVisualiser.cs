using Microsoft.VisualStudio.DebuggerVisualizers;
using System.Windows.Forms;

[assembly: System.Diagnostics.DebuggerVisualizer(
    typeof(Visualisers.StringDebuggerVisualiser),
    typeof(VisualizerObjectSource),
    Target = typeof(string),
    Description = "Visualiser Demo")]

namespace Visualisers
{

    public class StringDebuggerVisualiser : DialogDebuggerVisualizer
    {
        protected override void Show(IDialogVisualizerService windowService, IVisualizerObjectProvider objectProvider)
        {
            MessageBox.Show(objectProvider.GetObject().ToString());
        }

        public static void TestShowVisualizer(object objectToVisualize)
        {
            VisualizerDevelopmentHost visualizerHost = new VisualizerDevelopmentHost(objectToVisualize, typeof(StringDebuggerVisualiser));
            visualizerHost.ShowVisualizer();
        }
    }
}
