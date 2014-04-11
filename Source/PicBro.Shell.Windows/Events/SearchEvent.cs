using System.Collections.Generic;
using Microsoft.Practices.Prism.Events;
using PicBro.DataModel.Windows;

namespace PicBro.Shell.Windows.Events
{
    public class SearchEvent : CompositePresentationEvent<List<ImageModel>>
    {
    }
}
