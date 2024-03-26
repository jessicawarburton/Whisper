using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using Whisper.Core.Models.Generation;

namespace Whisper.Modules.MemorablePasswordGenerator
{
	public class MemorablePasswordContent : ContentBase
	{
        private readonly string _passwordString;

        public MemorablePasswordContent(string passwordString)
        {
            _passwordString = passwordString;
            PublicPreviewText = passwordString;
            PrivatePreviewText = passwordString;
            Mdl2Icon = WebUtility.HtmlDecode("&#xE939;");
        }

        public override string PublicPreviewText { get; }

        public override string PrivatePreviewText { get; }

        public override string Mdl2Icon { get; }

        public override void SetToClipboard(IClipboard clipboard)
        {
            clipboard.SetClipboardText(_passwordString);
        }
    }
}
