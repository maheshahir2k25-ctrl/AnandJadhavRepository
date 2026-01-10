using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpTutorial.DesignPatterns.Structural
{
    public interface IProduct
    {
        void AddFeatures();
    }

    public class BasicProduct : IProduct
    {
        public void AddFeatures()
        {
            Console.WriteLine("Added Basic Features");
        }
    }

    public abstract class ProductDecorator : IProduct
    {
        protected IProduct _product;
        public ProductDecorator(IProduct product)
        {
            _product = product;
        }
        public virtual void AddFeatures()
        {
            _product.AddFeatures();
        }
    }

    public class ProductWithVoiceCommands : ProductDecorator
    {
        public ProductWithVoiceCommands(IProduct product) : base(product)
        {
        }
        public override void AddFeatures()
        {
            base.AddFeatures();
            this.AddVoiceCommands();

        }
        public void AddVoiceCommands()
        {
            Console.WriteLine("Added Voice Command Feature");
        }
    }

    public class ProductWithFaceDetection : ProductDecorator
    {
        public ProductWithFaceDetection(IProduct product) : base(product)
        {
        }
        public override void AddFeatures()
        {
            base.AddFeatures();
            this.AddFaceDetection();
        }
        public void AddFaceDetection()
        {
            Console.WriteLine("Added Face Detection Feature");
        }
    }


    public class Decorator2Test
    {
        public IProduct Main()
        {
            //IProduct basicProduct = new BasicProduct();
            //Console.WriteLine("----Basic Product----");
            //basicProduct.AddFeatures();
            //Console.WriteLine("----Product with Voice Commands----");
            //IProduct voiceCommandProduct = new ProductWithVoiceCommands(basicProduct);
            //voiceCommandProduct.AddFeatures();
            //Console.WriteLine("----Product with Face Detection and Voice Commands----");
            //IProduct advancedProduct = new ProductWithFaceDetection(voiceCommandProduct);
            //advancedProduct.AddFeatures();

            // 1. Start with the base (The raw product)
            IProduct myProduct = new BasicProduct();

            // 2. Check customer preference: "Do they want Voice Commands?"
            // If yes, we wrap the current product in that layer.
            if (UserPreferences.HasVoiceCommands)
            {
                myProduct = new ProductWithVoiceCommands(myProduct);
            }

            // 3. Check customer preference: "Do they want Face Detection?"
            // If yes, we wrap it again.
            if (UserPreferences.HasFaceDetection)
            {
                myProduct = new ProductWithFaceDetection(myProduct);
            }

            myProduct.AddFeatures();

            return myProduct;
        }
    }


    public class UserPreferences
    {
        public const bool HasVoiceCommands = false;
        public const bool HasFaceDetection = false;
    }

}
