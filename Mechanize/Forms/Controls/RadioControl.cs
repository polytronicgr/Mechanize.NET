// ******************************************************************
// Copyright (c) William Bradley
// This code is licensed under the MIT License (MIT).
// THE CODE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
// IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM,
// DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
// TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH
// THE CODE OR THE USE OR OTHER DEALINGS IN THE CODE.
// ******************************************************************

using Mechanize.Forms.Controls.Options;
using Mechanize.Html;
using System.Collections.Generic;
using System.Linq;

namespace Mechanize.Forms.Controls
{
    /// <summary>
    /// Radio Control <para/>
    /// Covers: INPUT/RADIO <para/>
    /// Only allows one Option to be selected at any time.
    /// </summary>
    public class RadioControl : ListControl
    {
        internal RadioControl(HtmlForm Form, IHtmlNode Node) : base(Form, Node)
        {
            _Options = new List<ListOption>();
            AddOption(Node);
        }

        /// <summary>
        /// Adds an option to the Group.
        /// </summary>
        /// <param name="Option">Node to Parse and add.</param>
        internal void AddOption(IHtmlNode Option)
        {
            _Options.Add(new RadioOption(this, Option));
        }

        /// <summary>
        /// The Available options for this Control to Select from.
        /// </summary>
        public override IReadOnlyList<ListOption> Options => _Options;

        /// <summary>
        /// The current Selected Item for this Control. Use <see cref="ListControl.Select(ListOption)"/> to change it.
        /// </summary>
        public RadioOption Selected => _Options.Cast<RadioOption>()
            .FirstOrDefault(item => item.Selected);

        /// <summary>
        /// The underlying value from the Selection, equivalent to using <see cref="ListControl.Select(string)"/>.
        /// </summary>
        public override string Value
        {
            get => Selected.TransmitValue;
            set
            {
                CheckSetAttribute();
                Select(value);
            }
        }
    }
}