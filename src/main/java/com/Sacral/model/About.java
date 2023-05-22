@Entity
@Table(name = "About")
public class About {

    @Id
    @GeneratedValue(strategy = GenerationType.AUTO)
    private Long id;

    @Column(name = "introduction")
    private String introduction;

    @Column(name = "goals")
    private String goals;

    // Getters and setters
    // ...

}