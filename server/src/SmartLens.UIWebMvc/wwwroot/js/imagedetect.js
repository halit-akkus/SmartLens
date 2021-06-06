async function GetImageDetected()
{
    var base64 = await FileToBase64()

    //Obj of data to send in future like a dummyDb
    const ImageDetect = { imageBase64: base64 };

    //POST request with body equal on data in JSON format
    fetch('/Home/Index', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(ImageDetect),
    })
        .then((response) => response.text())
        //Then with the data from the response in JSON...
        .then((data) => {
            console.log('Success:', data);
        })
        //Then with the error genereted...
        .catch((error) => {
            alert('Error:', error);
        });


}

async function FileToBase64()
{
    const file = document.querySelector('#myfile').files[0];
    return await toBase64(file);
}


const toBase64 = file => new Promise((resolve, reject) => {
    const reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = () => resolve(reader.result);
    reader.onerror = error => reject(error);
});