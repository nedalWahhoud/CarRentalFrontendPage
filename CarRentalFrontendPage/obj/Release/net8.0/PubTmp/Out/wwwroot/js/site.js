/* footer */
function openMap(lat, lng) {
        window.open(`https://www.google.com/maps?q=${lat},${lng}`, "_blank");
}
function openEmail(email) {
        const subject = encodeURIComponent("Anfrage zur Fahrzeugvermietung");
    const body = encodeURIComponent("Hallo, ich habe eine Frage...");
    window.location.href = `mailto:${email}?subject=${subject}&body=${body}`;
}

function openPhone(number) {
        window.location.href = `tel:${number}`;
}

/* header */
function goToCar(id) {
        window.location.href = `/car/${id}`;
}
function openBooking(carName) {
        let message = "Hi, ich möchte ein Fahrzeug mieten / reservieren.";
    if (carName) {
        message = `Hi, ich möchte das Fahrzeug '${carName}' mieten / reservieren.`;
        }

    const url = `https://wa.me/?text=${encodeURIComponent(message)}`;
    window.open(url, "_blank");
}
function openCarMenu() {
        document.getElementById("carMenu").style.display = "block";
}
function closeCarMenu() {
        document.getElementById("carMenu").style.display = "none";
}
/* */
function goHome() {
    window.location.href = "/";
}

function openWhatsApp(message) {
    const url = `https://wa.me/?text=${encodeURIComponent(message)}`;
    window.open(url, "_blank");
}

function openWhatsApp(message) {
    const url = `https://wa.me/?text=${encodeURIComponent(message)}`;
    window.open(url, "_blank");
}

function openPhone(phoneNumber) {
    window.location.href = `tel:${phoneNumber}`;
}

function showImage(url) {
    document.getElementById("modalImg").src = url;
    document.getElementById("imageModal").style.display = "flex";
}

function closeImage() {
    document.getElementById("imageModal").style.display = "none";
}

function scrollToPrice() {
    document.getElementById("priceSection").scrollIntoView({ behavior: 'smooth' });
}

function openWhatsApp(msg) {
    window.open("https://wa.me/?text=" + encodeURIComponent(msg), "_blank");
}
function onBook(carName, priceType) {

    let rentalPeriod = "";

    switch (priceType) {
        case "weekday":
            rentalPeriod = "an den Wochentagen";
            break;

        case "weekend_day":
            rentalPeriod = "am Wochenende";
            break;

        case "weekend":
            rentalPeriod = "für das Ganze Wochenende";
            break;

        case "weekly":
            rentalPeriod = "für ganze Woche";
            break;
    }

    const message = `Hey, Ich möchte den ${carName} ${rentalPeriod} mieten. Bitte senden Sie mir weitere Informationen.`;

    openWhatsApp(message);
}

/* */
 window.scrollHelper = {
    onScrollEnd: function (dotnetObj) {
        let isLoading = false; // 🚫 Verhindert Wiederholung
        window.addEventListener("scroll", function () {

            const scrollPosition = window.innerHeight + window.scrollY;
            let pageHeight = document.body.scrollHeight;

            // Die Footer sollte nicht zur Seitenlänge gezählt werden.
            const footer = document.getElementById("page-footer");
            if (footer) {
                pageHeight -= footer.offsetHeight;
            }

            if (scrollPosition >= pageHeight - 2 && !isLoading) {
                isLoading = true;
                try {
                    dotnetObj.invokeMethodAsync("OnScrollEndReached");
                }
                catch (err) {
                    console.error("Fehler beim Aufrufen der .NET-Methode:", err);
                }
                finally {
                    setTimeout(() => {
                        isLoading = false;
                    }, 500);
                }
            }
        });
    }
};
    function showalert(message) {
        alert(message);
    }
        window.whatsappRedirect = {
    openWhatsApp: function(phone, message) {
        const number = String(phone).replace(/\D/g, '');
        const text = message ? encodeURIComponent(message) : '';

        // الروابط
        const appUrl = text
            ? `whatsapp://send?phone=${number}&text=${text}`
            : `whatsapp://send?phone=${number}`;
        const webUrl = text
            ? `https://api.whatsapp.com/send?phone=${number}&text=${text}`
            : `https://wa.me/${number}`;

        // فحص نوع الجهاز
        const isMobile = /Android|iPhone|iPad|iPod|Opera Mini|IEMobile|WPDesktop/i.test(navigator.userAgent);

        if (isMobile) {
            // على الموبايل: حاول فتح التطبيق أولًا
            const now = Date.now();
            window.location = appUrl;
        } else {
            // على الكمبيوتر: افتح الرابط مباشرة على الويب
            window.open(webUrl, '_blank');
        }
    }
};
        window.mapRedirect = {
    openMap: function(latitude, longitude, label = '') {
        latitude = String(latitude).trim();
        longitude = String(longitude).trim();
        label = String(label || '').trim();

        // إذا كان هناك اسم، نستخدمه فقط كـ query، وإلا نستخدم الإحداثيات
        const query = label ? encodeURIComponent(label) : `${latitude},${longitude}`;

        // روابط تعتمد على الاسم أو الإحداثيات
        const appleUrl = `maps://?ll=${latitude},${longitude}`;
        const googleAppUrl = `comgooglemaps://?q=${query}`;
        const webUrl = `https://www.google.com/maps/search/?api=1&query=${query}`;
        const androidUrl = `geo:${latitude},${longitude}?q=${query}`;

        const ua = navigator.userAgent || navigator.vendor || window.opera;
        const isIOS = /iPad|iPhone|iPod/.test(ua) && !window.MSStream;
        const isAndroid = /Android/.test(ua);

        const openWebFallback = () => window.open(webUrl, '_blank');

        if (isIOS) {
            // iOS: حاول Apple Maps أولاً
            window.location = appleUrl;

            // بعد ثانية: جرب Google Maps App
            setTimeout(() => {
                window.location = googleAppUrl;

                // بعد ثانية: افتح Web كخيار أخير
                setTimeout(() => openWebFallback(), 1000);
            }, 1000);

        } else if (isAndroid) {
            // Android: استخدم geo URI
            window.location = androidUrl;

            // fallback للويب بعد ثانية
            setTimeout(() => openWebFallback(), 1000);

        } else {
            // أي جهاز آخر → افتح Web مباشرة
            openWebFallback();
        }
    }
};
 window.scrollToId = function (id) {
            const element = document.getElementById(id);
            if (element) {
                element.scrollIntoView({ behavior: "smooth", block: "start" });
            }
        };
