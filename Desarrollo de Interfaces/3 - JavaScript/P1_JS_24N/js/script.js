document.addEventListener("DOMContentLoaded", function () {
    fetch("http://camacho.atwebpages.com/carouselCiudades2/getCiudades.php")
        .then(r => r.json())
        .then(d => {
            const ciudadesMenosDe200 = d.filter(ciudad => ciudad.Habitantes < 200);

            mostrarVideosAleatorios(d);

            mostrarTabla(ciudadesMenosDe200);
        })
});

function mostrarVideosAleatorios(ciudades) {
    const v = document.getElementById("parrafo");

    ciudades = ciudades.sort(() => Math.random() - 0.5);

    ciudades.forEach(ciudad => {
        const video = document.createElement("video");
        video.src = ciudad.VIDEO;
        video.width = 320;
        video.height = 240;
        video.controls = true;

        v.appendChild(video);

        video.play();
        setTimeout(() => {
            video.pause();
            video.currentTime = 0;
        }, 5000);
    });
}

function mostrarTabla(ciudades) {
    const cuerpo = document.querySelector("tbody");

    ciudades.forEach(ciudad => {
        const row = document.createElement("tr");
        row.innerHTML = `
            <td>${ciudad.Ciudad}</td>
            <td>${ciudad.Habitantes}</td>
            <td><a href="${ciudad.VIDEO}" target="_blank">Ver Video</a></td>
            <td><img src="${ciudad.IMAGEN}" width="50" height="50" alt="Imagen de ${ciudad.Ciudad}"></td>
            <td><a href="${ciudad.MAPA}" target="_blank">Ver Mapa</a></td>
            <td>${ciudad.ID}</td>
        `;
        cuerpo.appendChild(row);
    });
}






