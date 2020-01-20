﻿// Copyright (c) ppy Pty Ltd <contact@ppy.sh>. Licensed under the MIT Licence.
// See the LICENCE file in the repository root for full licence text.

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Framework.Graphics.UserInterface;
using osu.Game.Graphics;
using osu.Game.Graphics.UserInterface;

namespace osu.Game.Overlays
{
    public abstract class BreadcrumbControlOverlayHeader : ControllableOverlayHeader<string>
    {
        protected OverlayHeaderBreadcrumbControl BreadcrumbControl;

        protected override TabControl<string> CreateTabControl() => BreadcrumbControl = new OverlayHeaderBreadcrumbControl();

        protected BreadcrumbControlOverlayHeader(OverlayColourScheme colourScheme)
            : base(colourScheme)
        {
        }

        [BackgroundDependencyLoader]
        private void load(OsuColour colours)
        {
            BreadcrumbControl.AccentColour = colours.ForOverlayElement(ColourScheme, 1, 0.75f);
        }

        public class OverlayHeaderBreadcrumbControl : BreadcrumbControl<string>
        {
            public OverlayHeaderBreadcrumbControl()
            {
                RelativeSizeAxes = Axes.X;
            }

            protected override TabItem<string> CreateTabItem(string value) => new ControlTabItem(value);

            private class ControlTabItem : BreadcrumbTabItem
            {
                protected override float ChevronSize => 8;

                public ControlTabItem(string value)
                    : base(value)
                {
                    Text.Font = Text.Font.With(size: 14);
                    Chevron.Y = 3;
                    Bar.Height = 0;
                }
            }
        }
    }
}
