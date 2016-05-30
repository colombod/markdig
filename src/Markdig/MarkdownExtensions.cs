﻿// Copyright (c) Alexandre Mutel. All rights reserved.
// This file is licensed under the BSD-Clause 2 license. 
// See the license.txt file in the project root for more information.
using Markdig.Extensions.Abbreviations;
using Markdig.Extensions.AutoIdentifiers;
using Markdig.Extensions.Bootstrap;
using Markdig.Extensions.Cites;
using Markdig.Extensions.CustomContainers;
using Markdig.Extensions.DefinitionLists;
using Markdig.Extensions.Emoji;
using Markdig.Extensions.EmphasisExtra;
using Markdig.Extensions.Figures;
using Markdig.Extensions.Footers;
using Markdig.Extensions.Footnotes;
using Markdig.Extensions.GenericAttributes;
using Markdig.Extensions.Hardlines;
using Markdig.Extensions.ListExtra;
using Markdig.Extensions.Mathematics;
using Markdig.Extensions.Medias;
using Markdig.Extensions.SmartyPants;
using Markdig.Extensions.Tables;
using Markdig.Parsers;
using Markdig.Parsers.Inlines;

namespace Markdig
{
    /// <summary>
    /// Provides extension methods for <see cref="MarkdownPipeline"/> to enable several Markdown extensions.
    /// </summary>
    public static class MarkdownExtensions
    {
        /// <summary>
        /// Uses all extensions except the Emoji.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseAllExtensions(this MarkdownPipelineBuilder pipeline)
        {
            return pipeline
                .UseAbbreviation()
                .UseAutoIdentifier()
                .UseBootstrap()
                .UseCite()
                .UseCustomContainer()
                .UseDefinitionList()
                .UseEmphasisExtra()
                .UseFigure()
                .UseFooter()
                .UseFootnotes()
                .UseGridTable()
                .UseMath()
                .UseMedia()
                .UsePipeTable()
                .UseSoftlineBreakAsHardlineBreak()
                .UseSmartyPants()
                .UseGenericAttributes(); // Must be last as it is one parser that is modifying other parsers
        }

        /// <summary>
        /// Uses the custom container extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseCustomContainer(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<CustomContainerExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the media extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipelineBuilder UseMedia(this MarkdownPipelineBuilder pipeline, MediaOptions options = null)
        {
            if (!pipeline.Extensions.Contains<MediaExtension>())
            {
                pipeline.Extensions.Add(new MediaExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the auto-identifier extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipelineBuilder UseAutoIdentifier(this MarkdownPipelineBuilder pipeline, AutoIdentifierOptions options = AutoIdentifierOptions.Default)
        {
            if (!pipeline.Extensions.Contains<AutoIdentifierExtension>())
            {
                pipeline.Extensions.Add(new AutoIdentifierExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the SmartyPants extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipelineBuilder UseSmartyPants(this MarkdownPipelineBuilder pipeline, SmartyPantOptions options = null)
        {
            if (!pipeline.Extensions.Contains<SmartyPantsExtension>())
            {
                pipeline.Extensions.Add(new SmartyPantsExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the boostrap extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseBootstrap(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<BootstrapExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the math extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseMath(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<MathExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the figure extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseFigure(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<FigureExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the custom abbreviation extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseAbbreviation(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<AbbreviationExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the definition lists extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseDefinitionList(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<DefinitionListExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the pipe table extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipelineBuilder UsePipeTable(this MarkdownPipelineBuilder pipeline, PipeTableOptions options = null)
        {
            if (!pipeline.Extensions.Contains<PipeTableExtension>())
            {
                pipeline.Extensions.Add(new PipeTableExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the grid table extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseGridTable(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<GridTableExtension>();
            return pipeline;
        }


        /// <summary>
        /// Uses the cite extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseCite(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<CiteExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the footer extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseFooter(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<FooterExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the footnotes extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseFootnotes(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<FootnoteExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the softline break as hardline break extension
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseSoftlineBreakAsHardlineBreak(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<SoftlineBreakAsHardlineExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the strikethrough superscript, subscript, inserted and marked text extensions.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <param name="options">The options to enable.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipelineBuilder UseEmphasisExtra(this MarkdownPipelineBuilder pipeline, EmphasisExtraOptions options = EmphasisExtraOptions.Default)
        {
            if (!pipeline.Extensions.Contains<EmphasisExtraExtension>())
            {
                pipeline.Extensions.Add(new EmphasisExtraExtension(options));
            }
            return pipeline;
        }

        /// <summary>
        /// Uses the list extra extension to add support for `a.`, `A.`, `i.` and `I.` ordered list items.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>
        /// The modified pipeline
        /// </returns>
        public static MarkdownPipelineBuilder UseListExtra(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<ListExtraExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the generic attributes extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseGenericAttributes(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<GenericAttributesExtension>();
            return pipeline;
        }

        /// <summary>
        /// Uses the emoji and smiley extension.
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder UseEmojiAndSmiley(this MarkdownPipelineBuilder pipeline)
        {
            pipeline.Extensions.AddIfNotAlready<EmojiExtension>();
            return pipeline;
        }

        /// <summary>
        /// This will disable the HTML support in the markdown processor (for constraint/safe parsing).
        /// </summary>
        /// <param name="pipeline">The pipeline.</param>
        /// <returns>The modified pipeline</returns>
        public static MarkdownPipelineBuilder DisableHtml(this MarkdownPipelineBuilder pipeline)
        {
            var parser = pipeline.BlockParsers.Find<HtmlBlockParser>();
            if (parser != null)
            {
                pipeline.BlockParsers.Remove(parser);
            }

            var inlineParser = pipeline.InlineParsers.Find<AutolineInlineParser>();
            if (inlineParser != null)
            {
                inlineParser.EnableHtmlParsing = false;
            }
            return pipeline;
        }
    }
}