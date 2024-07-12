namespace Jain_Mandir_Pro
{
    using System;
    using System.AddIn;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.IO;
    using System.Xml.Serialization;
    using System.Globalization;
    using Xpertdoc.DocumentServices.AddIn.Views;
    using Xpertdoc.DocumentServices.Operations;
    using Xpertdoc.Portal.AddIn;

    /// <summary>
    /// Represents the operation of the BatchOperationAddIn
    /// </summary>
    [AddIn("BatchOperationAddIn", Publisher = "Publisher", Version = "1.0.0", Description = "Sample for Xpertdoc Batch Operation Add-Ins")]
    public class BatchOperationAddIn : AddInBase, IBatchOperationAddIn
    {
        #region Fields

        /// <summary>
        /// The sample metadata
        /// </summary>
        private static readonly Lazy<string> SampleMetadata = new Lazy<string>(() =>
        {
            var ressourceName = string.Format(
                CultureInfo.InvariantCulture,
                "{0}.{1}",
                typeof(BatchOperationAddIn).Namespace,
                "BatchOperationSampleMetadata.xml");

            using (var sampleMetadataStream = typeof(BatchOperationAddIn).Assembly.GetManifestResourceStream(ressourceName))
            {
                return new StreamReader(sampleMetadataStream).ReadToEnd();
            }
        });

        /// <summary>
        /// The metadata serializer
        /// </summary>
        private static readonly XmlSerializer MetadataSerializer = new XmlSerializer(typeof(BatchOperationMetadata));

        #endregion

        #region Methods

        /// <summary>
        /// Gets the sample metadata.
        /// </summary>
        /// <returns>The Sample Metadata Lazy String.</returns>
        public override string GetSampleMetadata()
        {
            return SampleMetadata.Value;
        }

        /// <summary>
        /// Executes the specified context.
        /// </summary>
        /// <param name="context">The context </param>
        /// <returns> the result of the operation </returns>
        public IBatchOperationResult Execute(IBatchOperationContext context)
        {
            return new SimpleBatchOperationResult();
        }

        #endregion
    }
}
