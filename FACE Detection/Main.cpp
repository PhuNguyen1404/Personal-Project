#include <opencv2/imgcodecs.hpp>
#include <opencv2/highgui.hpp>
#include <opencv2/imgproc.hpp>
#include <opencv2/objdetect.hpp>
#include <iostream>

using namespace std;
using namespace cv;

/*void main() {


	string path = "face.jpg";
	Mat img = imread(path);
	imshow("Facing", img);
	waitKey(0);
}*/

void main() {
	VideoCapture Vid(0);
	CascadeClassifier facedetect;
	Mat img;
	facedetect.load("haarcascade_frontalface_default.xml");

	while (true) {
		Vid.read(img);

		vector<Rect> faces;

		facedetect.detectMultiScale(img, faces, 1.3, 5);

		cout << faces.size() << endl;

		for (int i = 0; i < faces.size(); i++) {
			rectangle(img, faces[i].tl(), faces[i].br(), Scalar(50, 50, 255), 3);
			rectangle(img, Point(0, 0), Point(250, 70), Scalar(50, 50, 255), FILLED);
			putText(img, to_string(faces.size()) + " Face founded", Point(10, 40), FONT_HERSHEY_DUPLEX, 1, Scalar(255, 255, 255), 1);
		}

		
		imshow("Facing", img);
		waitKey(1);
	}
}