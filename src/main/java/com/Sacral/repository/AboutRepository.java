·       User should be able to send email to NDM from default email.

@Repository
public interface AboutRepository {

    // Method to get the brief introduction about the website
    public String getIntroduction();

    // Method to get the goals of the NDM website
    public String getGoals();

    // Method to send an email to NDM from default email
    public void sendEmail(String email);

}