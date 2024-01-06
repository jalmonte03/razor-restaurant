const newsletterForm = document.querySelector("#newsletter-form");

newsletterForm.addEventListener("submit", async (e) => {
    e.preventDefault();


    const antiforgeryToken = document.querySelector("input[name=\"__RequestVerificationToken\"]").value;
    
    const newsletterContentEl = document.querySelector(".newsletter-content");
    const newsletterFormEl = document.querySelector("#newsletter-form");
    const template = document.querySelector("#newsletter-form-submitted");

    if (newsletterFormEl){
        const email = document.querySelector("#newsletter_email").value;
        const formData = new FormData();
        formData.append("email", email);
        
        const response = await fetch("/api/newsletter", {
            method: "POST",
            headers: {
                RequestVerificationToken: antiforgeryToken,
            },
            body: formData
        });

        if (response.ok) {
            const data = await response.json();
            const clonedTemplate = template.content;
            
            newsletterFormEl.remove();
            newsletterContentEl.appendChild(clonedTemplate);
        }
    }

});