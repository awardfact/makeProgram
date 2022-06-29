package tacos;

import java.util.List;


import javax.validation.constraints.NotNull;
import javax.validation.constraints.Size;

import lombok.Data;
import java.util.Date;


@Data
public class Taco {

	@NotNull
	@Size(min=5 , message= "Name must be at least 5 5 characters long")
	private String name;
	
	
	private Long id;
	private Date createdAt;
	
	@Size(min=1 , message="Yout must choose at least 1 ingredient")
	private List<Ingredient> ingredients;
	
}
