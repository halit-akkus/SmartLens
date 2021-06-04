async function GetImageDetected()
{
    var url = `https://localhost:44316/ImageDetected/Detected`
    var base64 = await FileToBase64()

    console.log(base64)

    var ImageDetect = {
        imageBase64 : 'test'
    }

    fetch(url,{
        method: 'post',
        body: ImageDetect
    })
        .then(result => alert(result))
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