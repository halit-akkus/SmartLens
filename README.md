# TensorflowObjectDetectionApi
Hızlı bir şekilde nesne tanımaya başlamak için.
NOT: Uygulamada belirtilen port'a aşağıda gösterilen model örneğinden gönderirseniz yani bir guid ve bir görüntü gönderirseniz, script ilgilin görüntüde nesne tanıma yapacaktır.
{
guid: UserId,
byte[]: Image
}
# Anaconda kurulumu

Anaconda 5.1.0 versiyonunu indirin. Bu versiyon tensorflow 1.13.2 versiyonu ile uyumludur.
Bulacağınız adres: https://repo.anaconda.com/archive/

# Tensorflow kurulumu

tensorflow krulumu için aşağıdaki komutu kullanın.

Paylaştığım dosyalar, 1.13.2 versiyonunu destekler.

pip install --upgrade tensorflow==1.13.2

Kurulum tamamlandıktan sonra aşağıdaki komutu çalıştırın.

>>> import tensorflow as tf
>>> hello = tf.constant('Hello, TensorFlow!')
>>> sess = tf.Session()
>>> print(sess.run(hello))



'Hello, TensorFlow!' mesajını alıyorsanız tensorflow kurulumu başarılı demektir.



