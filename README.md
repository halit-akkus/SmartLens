# SMART LENS 😎
Bu projede, görme engelli bireyler için, bulut teknoloji ve derin öğrenme destekli yapay görme sistemi geliştirme amaçlandı.


# Çalışma prensibi?
Görme engelli bireyin telefonundaki mobil uygulama ile etrafındaki nesnelerin görüntüleri çekilip merkezi sunucuya iletilir. Merkezi sunucu ise load balancing yaparak ilgili musait nesne tanıma sunucusuna iletir. Ve nihai sonuçlar üretildikten sonra geriye merkezi sunucuya cevaplar gönderilir ve son olarak görme engelli bireye ulaşır ve sesli çıktı üretilir.

Merkezi sunucudan kısaca bahsedecek olursak, projenin bir merkezi sunucusu(.NET CORE) var. Bu sunucuyu; Load balancing, crud, auth, validation, aspect gibi işlemlerimizi
yapmak için kullanıyoruz. 

# Load balancing?
Nesne tanıma yük bakımından maliyetli bir işlemdir. Sunucu üzerinde dikey ölçekleme(daha güçlü bir sunucu) yapmak yerine,
yatay ölçekleme(aynı performans ile daha fazla sunucu) yapmayı tercih ettik. Dolayısıyla merkezi sunucumuz yanında asıl nesne tanıma işlemlerimiz için,
python kullandık. Python ile ile yazdığımız birden fazla instance'ı farklı farklı sunucularda deploy ettik.
Merkezi sunucumuz kendisine gelen bir görüntü bilgisini #"load balancing" yaparak musait sunuculara iletmektedir. İlgili sunucu aldığı görüntüyü model'den geçirerek,
çıkan sonucu bir array olarak geriye merkezi sunucuya iletmektedir. Son olarak validator işleminden sonra yanıtlar isteği gönderen istemciye ulaşır.



# KURULUM VE KULLANIM  🚀 

 ❗️ Bilgisayarınızda  anaconda "5.1.0" versiyonu kurulu değilse veya Tensorflow "1.13.2" sürümü kurulu değilse aşağıda # GENEL KURULUMLAR adımlarını takip edin.

➡ Öncelikle proje dosyalarını indiriyoruz.

➡ Daha sonra server/src/SmartLens.sln dosyasını açarak merkezi sunucu projesini açmış oluruz. 

➡ Projemizi derleyelim ve çalıştıralım. Merkezi sunucu başlayacaktır.

➡ Daha sonra server/object_detection/image_detected.bat ile python uygulamasını çalıştıralım. Veya cmd ile; python image_detected.py yazarak scripti çalıştırabilirsiniz.

➡ Nesne tanıma sunucusu başlamış oldu ve merkezi sunucudan verileri bekliyor.

➡ Daha sonra istemci olarak, .net ile test amaçlı yazılan projeyi açıyoruz. Bunun için; client/SmartLens.UITestClient/SmartLens.UITransmissionTestClient.sln 
projesini açarak derleyelim. İstemciyi sunucunun olduğu bilgisayarda çalıştırdığınız varsayılmıştır. Farklı bilgisayarlarda deneyecekseniz, ip adresini(varsayılan: 127.0.0.1) değiştirmeyi unutmayın.

➡️ Görüntü gönderimi başlamıştır. Sunucular ile istemciler arasında veri transferi sorunsuz ilerliyor olması gerekmektedir.

❗️ İstemci olarak, test istemcisi olduğundan bir kamera kullanılmamıştır. Görüntü olarak bilgisayarınızın sol üst köşesinden 500*500 çözünürlüğünde ekran kaydı göndermektedir.

Bir sorun halinde, tavsiye/öneri durumlarında veya geliştirme isteğiniz olduğunda bana bildirmenizden memnuniyet duyarım.

İletişim: halitakkus03@gmail.com



# GENEL KURULUMLAR (tensorflow/anaconda)

Tensorflow object detection api kullanılmıştır.

# Anaconda "5.1.0" kurulumu

Anaconda 5.1.0 versiyonunu indirin. Bu versiyon tensorflow 1.13.2 versiyonu ile uyumludur.
Bulacağınız adres: https://repo.anaconda.com/archive/

# Tensorflow "1.13.2" kurulumu

tensorflow krulumu için aşağıdaki komutu kullanın.

Paylaştığım dosyalar, 1.13.2 versiyonunu destekler.

pip install --upgrade tensorflow==1.13.2

Kurulum tamamlandıktan sonra aşağıdaki komutu çalıştırın.

>>> import tensorflow as tf
>>> hello = tf.constant('Hello, TensorFlow!')
>>> sess = tf.Session()
>>> print(sess.run(hello))



'Hello, TensorFlow!' mesajını alıyorsanız tensorflow kurulumu başarılı demektir.


 Projede "ssd_mobilenet_v1_coco" modeli kullanılmıştır.Nesne tanımada daha isabetli sonuçlar elde etmek istiyorsanız veya daha performanslı modelleri incelemek istiyorsanız, aşağıda daha farklı modelleri kullanabileceğiniz bağlantı adresini bırakıyorum.
 

https://github.com/tensorflow/models/blob/master/research/object_detection/g3doc/tf1_detection_zoo.md


# Örnek video

https://www.youtube.com/watch?v=rr0UUIytpO8

# Görüntüler


![6](https://user-images.githubusercontent.com/46889995/128303136-d6883c07-ddaf-4210-9937-6b8f82911856.jpg)

Test görüntüsü.

![5](https://user-images.githubusercontent.com/46889995/128303207-d7b2750f-f2ff-4295-9764-a5abc2381f1a.jpg)

Test görüntüsü merkezi sunucuya ulaştı.

![1](https://user-images.githubusercontent.com/46889995/128303104-54c63f07-a6cc-4af8-86b7-33c141a9af8f.jpg)


❗(Load balancing yapılarak) Python sunucusuna ulaştı ve sonuç görüntü(Bazı nesneler).



![2](https://user-images.githubusercontent.com/46889995/128303168-9952867b-203a-4546-aa86-3b2eb82e135a.jpg)

![3](https://user-images.githubusercontent.com/46889995/128303174-11d38e2e-8e30-4e14-b453-e092fd752f63.jpg)

![4](https://user-images.githubusercontent.com/46889995/128303181-e5cd10dd-233e-49bc-b503-d9926cb0980a.jpg)




❗️ Bu fotoğrafta kısacası, test istemcisi görüntüyü merkezi sunucuna yolluyor, merkezi sunucu ise load balancing yaparak ilgili python nesne tanıma sunucusuna yolluyor,
tanınan nesneler bir array([1,3,5,10]) olarak merkezi sunucuya daha sonrasında ise istemciye geri ulaşıyor.
Test olarak ise fotoğraf'ta görüldüğü üzere test amaçlı youtube ile bir video oynatılmıştır.

Ayrıca "swagger" dökümantasyon aracını kullanarak bir api vasıtası ile servis olarak kullanabilme imkanımız vardır. 

![alt text](https://cdn1.bbcode0.com/uploads/2021/6/4/6f80998016f17150fb4033e1ac82eccc-full.png)

Örnek amaçlı servisimize "fetch" isteklerinde bulunan bir mvc uygulamasından kareler.

![alt text](https://cdn1.bbcode0.com/uploads/2021/6/4/d2c7d3aabac966f29b3e3f1449244b5d-full.png)


![alt text](https://cdn1.bbcode0.com/uploads/2021/6/4/42fc7490d48df0eb4ca2ea5197af8a26-full.png)


![monolithic architecture](https://user-images.githubusercontent.com/46889995/128303370-4af8a18c-c7ad-4082-8b02-2e10caec4ac3.png)

👤
Github: @halitakkus
LinkedIn: @haliakkus
Web Site: halit.org
