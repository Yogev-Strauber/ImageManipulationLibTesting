using ImageManipulationLibTesting;

Random random = new Random();
int x = random.Next();
Image image = Image.Load(@"C:\Users\yogev.DRUSHIM\Desktop\outputs\sample.jpg");
int desiredHeight = 50;
int desiredWidth = 50;

Image resizedImage = ImageUtils.ResizeImage(image, desiredHeight, desiredWidth);
resizedImage.Save(@$"C:\Users\yogev.DRUSHIM\Desktop\outputs\output_{x}.jpg");


